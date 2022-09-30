using System;

namespace Shared.Model
{
    public class Order
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
