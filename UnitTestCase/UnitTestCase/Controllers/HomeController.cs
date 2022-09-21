using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IActionResult Get()
        {
            var encoded= Convert.ToBase64String(Encoding.UTF8.GetBytes("Vikash Verma"));
            return Ok(new { Value = encoded });
        }
    }
}
