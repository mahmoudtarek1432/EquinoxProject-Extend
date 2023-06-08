using Equinox.Domain.Core.Events;
using Equinox.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Infra.Data.Repository.EventSourcing
{
    public class EventStoreMongoRepository : IEventStoreRepository
    {
        EventStoreMongoContext _ctx;
        public EventStoreMongoRepository()
        {
            _ctx =  new EventStoreMongoContext();
        }

        public async Task<IList<StoredEvent>> All(Guid aggregateId)
        {
            return await _ctx.EventStoreSet.AsQueryable().Where(es => es.AggregateId == aggregateId).ToListAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Store(StoredEvent theEvent)
        {
            _ctx.EventStoreSet.InsertOne(theEvent);
        }
    }
}
