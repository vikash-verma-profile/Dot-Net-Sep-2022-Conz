using CustomerAPP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController : ControllerBase
    {
        CustomerDBContext db;

        public CustomerController(CustomerDBContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return db.Customers;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            var response = new { Status="Success"};
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var data = db.Customers.Where(x => x.Id == id).FirstOrDefault();
            db.Customers.Remove(data);
            db.SaveChanges();
            //
            var response = new { Status = "Success" };
            return Ok(response);
        }
    }
}
