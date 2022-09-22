using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Services
{
   public interface ICatalogService
    {
        IEnumerable<TblProduct> findall();
    }
}
