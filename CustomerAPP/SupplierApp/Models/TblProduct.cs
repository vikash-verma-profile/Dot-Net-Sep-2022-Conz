﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SupplierApp.Models
{
    public partial class TblProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? Inventory { get; set; }
    }
}
