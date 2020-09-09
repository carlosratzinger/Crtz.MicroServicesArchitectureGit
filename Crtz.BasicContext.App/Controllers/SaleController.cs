using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crtz.BasicContext.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Crtz.BasicContext.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        private SaleRegister saleRegister;

        public SaleController()
        {
            //saleRegister = new SaleRegister();
        }

        [HttpGet]
        public IEnumerable<Sale> Get()
        {
            //saleRegister.SetItem();
            return null;
        }
    }
}
