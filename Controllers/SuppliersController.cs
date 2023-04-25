using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private DataContext _dataContext;

        public SuppliersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("{id}")]
        public async Task<Supplier?> GetSupplier(long id)
        {
            Supplier supplier = await _dataContext.Suppliers.Include(p=>p.Products).FirstAsync(s=>s.SupplierId== id);

            if(supplier.Products != null)
            {
                foreach(Product p in supplier.Products)
                {
                    p.Supplier = null;
                }
            }

            return supplier;
        }



        //Invoke-RestMethod http://localhost:5000/api/suppliers/1 -Method PATCH -ContentType "application/json" -Body '[{"op":"replace",path:"city","value":"Stuttgart"}]'

        [HttpPatch("{id}")]
        public async Task<Supplier?> PatchSupplier(long id, JsonPatchDocument<Supplier> patchDoc)
        {
            Supplier? s = await _dataContext.Suppliers.FindAsync(id);

            if(s != null)
            {
                patchDoc.ApplyTo(s);
                await _dataContext.SaveChangesAsync();
            }

            return s;
        }
    }
}
