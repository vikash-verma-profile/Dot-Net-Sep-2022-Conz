using CustomerAPP.Models;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBus bus;
        CustomerDBContext db ;
        public OrderController(IBus _bus, CustomerDBContext _db)
        {
            bus = _bus;
            db = _db;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(TblOrder order)
        {
            if (order != null)
            {
                db.TblOrders.Add(order);
                db.SaveChanges();
                Uri uri = new Uri("rabbitmq:localhost/orderQueue");
                var endpoint = await bus.GetSendEndpoint(uri);
                Order orderMessage = new Order();
                orderMessage.Inventory = order.Inventory;
                orderMessage.ProductId = order.ProductId;
                orderMessage.OrderNumber = order.OrderNumber;
                orderMessage.ProductColor = order.ProductColor;
                orderMessage.ProductName = order.ProductName;
                await endpoint.Send(orderMessage);
                return Ok(new { status = "Your order is placed" });
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("get-order")]
        public IEnumerable<TblOrder> getOrder()
        {
            return db.TblOrders;
        }
       
    }
}
