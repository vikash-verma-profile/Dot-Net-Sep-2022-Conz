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
    public class SupplierController : ControllerBase
    {

        CustomerDBContext db = new CustomerDBContext();
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
