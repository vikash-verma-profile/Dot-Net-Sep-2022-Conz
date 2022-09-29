using Consumer.Model;
using Consumer.Models;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer.Consumer
{
    public class VedioDeletedEventConsumer:IConsumer<VedioDeletedEvent>
    {
        VedioDBContext db = new VedioDBContext();
        public Task Consume(ConsumeContext<VedioDeletedEvent> context)
        {
            var message = context.Message.Title;
            var data = db.TblVedios.Where(x => x.Id == Convert.ToInt32(message)).FirstOrDefault();
            db.TblVedios.Remove(data);
            db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
