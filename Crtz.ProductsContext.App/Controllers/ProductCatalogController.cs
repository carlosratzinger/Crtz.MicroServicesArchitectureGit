using Crtz.Messages.Events;
using Crtz.ProductsContext.Core;
using Crtz.ProductsContext.Infra.Storage.InMemory;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using System;

namespace Crtz.ProductsContext.App.Controllers
{
    [Route("ProductCatalog")]
    [ApiController]
    public class ProductCatalogController : ControllerBase
    {
        private ProductCatalogStorage storage;

        public ProductCatalogController()
        {
            storage = new ProductCatalogStorage();
        }

        [HttpGet, Route("")]
        public IActionResult GetAllProducts()
        {
            return Ok(storage.GetProducts());
        }

        [HttpPost, Route("")]
        public IActionResult AddNewProduct()
        {
            return Ok();
        }
    }
}