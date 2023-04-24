﻿using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private DataContext _dataContext;

        ProductsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _dataContext.Products;
        }

        [HttpGet("{id}")]
        public Product? GetProduct([FromServices] ILogger<ProductsController> logger)
        {
            logger.LogDebug("getProduct Action Invoked");
            return _dataContext.Products.FirstOrDefault();
        }

    }
}
