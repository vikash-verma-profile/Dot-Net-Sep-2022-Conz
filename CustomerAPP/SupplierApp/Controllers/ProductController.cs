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
        
        CustomerDBContext db;

        public ProductController(CustomerDBContext _db)
        {
            db = _db;
        }
        [HttpGet]
        [Route("get-products")]
        public IEnumerable<TblProduct> getProduct()
        {
            return db.TblProducts;
        }
    }
}
