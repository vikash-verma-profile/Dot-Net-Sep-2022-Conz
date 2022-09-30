using MassTransit;
using Shared.Model;
using SupplierApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplierApp.Consumers
{
    public class OrderConsumer:IConsumer<Order>
    {
        CustomerDBContext db = new CustomerDBContext();
        public Task Consume(ConsumeContext<Order> context)
        {
            var data = context.Message;
            var productdata = db.TblProducts.Where(x => x.Id == data.ProductId).FirstOrDefault();
            productdata.Inventory = productdata.Inventory - data.Inventory;
            db.TblProducts.Update(productdata);
            db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
