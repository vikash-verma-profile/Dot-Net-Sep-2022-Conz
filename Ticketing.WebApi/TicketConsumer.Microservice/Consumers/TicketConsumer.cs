using MassTransit;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketConsumer.Microservice.Consumers
{
    public class TicketConsumer:IConsumer<Ticket>
    {
        public Task Consume(ConsumeContext<Ticket> context)
        {
            var data = context.Message;
            return Task.CompletedTask;
        }
    }
}
