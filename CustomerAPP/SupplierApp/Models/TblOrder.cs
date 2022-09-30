using System;
using System.Collections.Generic;

#nullable disable

namespace SupplierApp.Models
{
    public partial class TblOrder
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string OrderNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductColor { get; set; }
        public string ProductSize { get; set; }
        public int? Inventory { get; set; }
    }
}
