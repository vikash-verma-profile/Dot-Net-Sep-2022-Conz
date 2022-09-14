using CustomerAPP.Models;
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
    public class CustomerController : ControllerBase
    {
        CustomerDBContext db = new CustomerDBContext();
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
    }
}
