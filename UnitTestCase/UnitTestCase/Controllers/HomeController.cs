using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
        [HttpPost,DisableRequestSizeLimit]
        public IActionResult upload()
        {
            var file = Request.Form.Files[0];
            var foldername = "Images";
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(),foldername);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(foldername,fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return Ok(new { dbPath });
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
