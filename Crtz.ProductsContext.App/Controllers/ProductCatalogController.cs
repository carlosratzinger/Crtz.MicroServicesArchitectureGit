using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using Crtz.ProductsContext.Core;
using Crtz.ProductsContext.Infra.Storage.EF;

namespace Crtz.ProductsContext.App.Controllers
{
    [Route("ProductCatalog")]
    [ApiController]
    public class ProductCatalogController : ControllerBase
    {
        private EntityFrameworkContext ctx;

        public ProductCatalogController()
        {
            
        }

        [HttpGet, Route("")]
        public IActionResult GetAllProducts()
        {
            List<Product> products;

            using (ctx = new EntityFrameworkContext())
            {
                products = ctx.Products.ToList();
            }

            return Ok(products);
        }

        [HttpPost, Route("")]
        public IActionResult AddNewProduct()
        {
            return Ok();
        }
    }
}