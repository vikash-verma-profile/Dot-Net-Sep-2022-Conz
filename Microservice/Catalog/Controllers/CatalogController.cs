using Catalog.Models;
using Catalog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        ICatalogService catalogService;
        public CatalogController(ICatalogService _catalogService)
        {
            catalogService = _catalogService;
        }
        [HttpGet]
        public IEnumerable<TblProduct> get()
        {
            return catalogService.findall();
        }
    }
}
