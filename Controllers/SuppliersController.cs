using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SuppliersController : ControllerBase
    {
        private DataContext _dataContext;

        public SuppliersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("{id}")]
        public async Task<Supplier?> GetSupplier(long supplierId)
        {
            return await _dataContext.Suppliers.FindAsync(supplierId);
        }
    }
}
