using Consumer.Model;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer.Consumer
{
    public class VedioDeletedEventConsumer:IConsumer<VedioDeletedEvent>
    {
        public Task Consume(ConsumeContext<VedioDeletedEvent> context)
        {
            var message = context.Message.Title;
            return Task.CompletedTask;
        }
    }
}
