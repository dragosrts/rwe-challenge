using Rwe.App.Abstractions;
using Rwe.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rwe.App.Services.Aggregates
{
    public class ControlDataAggregate
    {
        private readonly IWindparkClient windparkClient;
        private readonly IMessageProducer messageProducer;

        public ControlDataAggregate(IWindparkClient windparkClient, IMessageProducer messageProducer)
        {
            this.windparkClient = windparkClient;
            this.messageProducer = messageProducer;
        }

        public async Task<IEnumerable<Park>> AggregateControlData()
        {


            var controlData = new List<Park>();

            return controlData;
        }
    }
}
