using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class SupplierController : ControllerBase
    {

        CustomerDBContext db ;
        public SupplierController(CustomerDBContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<Supplier> Get()
        {
            return db.Suppliers;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Supplier customer)
        {
            db.Suppliers.Add(customer);
            db.SaveChanges();
            var response = new { Status = "Success" };
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var data = db.Suppliers.Where(x => x.Id == id).FirstOrDefault();
            db.Suppliers.Remove(data);
            db.SaveChanges();
            //
            var response = new { Status = "Success" };
            return Ok(response);
        }
    }
}
