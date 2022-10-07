using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UnitTestCase.Models;

namespace UnitTestCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        CustomerDBContext db = new CustomerDBContext();

        [HttpGet]
        [Route("get-images")]
        public IEnumerable<TblImage> getImages()
        {
            return db.TblImages;
        }
        public IActionResult Get()
        {
            var encoded= Convert.ToBase64String(Encoding.UTF8.GetBytes("Vikash Verma"));
            return Ok(new { Value = encoded });
        }
        [HttpPost,DisableRequestSizeLimit]
        public async Task<IActionResult> upload()
        {
            var file = Request.Form.Files[0];
            var pathToSave = Directory.GetCurrentDirectory();
            if (file.Length > 0)
            {
                try
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var _filename = Path.GetFileNameWithoutExtension(fileName);
                    fileName = _filename + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = fileName;
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    string connectionstring = "DefaultEndpointsProtocol=https;AccountName=sampleaccount551;AccountKey=BpG0LDh7UFiBd+L5rmXZcNX8VXbAVBc9rDER/kW48Te3aKvfl7tA/LZhCSPiDZTBfdPpHaO4i+qp+AStLSsweA==;EndpointSuffix=core.windows.net";
                    string containerName = "images";
                    BlobContainerClient container = new BlobContainerClient(connectionstring, containerName);
                    var blob = container.GetBlobClient(fileName);
                    var blobstream = System.IO.File.OpenRead(fileName);
                    await blob.UploadAsync(blobstream);
                    var URI = blob.Uri.AbsoluteUri;
                    TblImage obj = new TblImage();
                    obj.ImageUrl = dbPath;
                    db.TblImages.Add(obj);
                    db.SaveChanges();
                    return Ok(new { dbPath });
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
               
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
