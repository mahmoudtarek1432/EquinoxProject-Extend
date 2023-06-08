using Equinox.Domain.Core.Events;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Infra.Data.Context
{
    internal class EventStoreMongoContext
    {
        MongoClient mongoClient;
        public IMongoCollection<StoredEvent> EventStoreSet;
        public EventStoreMongoContext()
        {
            var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
            if (connectionString == null)
            {
                mongoClient = new MongoClient(connectionString);
                var EventStoredb = mongoClient.GetDatabase("EventStoreDB");
                EventStoreSet = EventStoredb.GetCollection<StoredEvent>("StoredEvent");
            }
        }
    }
}
