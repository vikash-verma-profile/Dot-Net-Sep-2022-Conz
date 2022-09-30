using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplierApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplierApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        CustomerDBContext db = new CustomerDBContext();
        [HttpGet]
        [Route("get-products")]
        public IEnumerable<TblProduct> getProduct()
        {
            return db.TblProducts;
        }
    }
}
