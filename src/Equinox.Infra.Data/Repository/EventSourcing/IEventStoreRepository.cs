using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Equinox.Domain.Core.Events;

namespace Equinox.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository
    {
        void Store(StoredEvent theEvent);
        Task<IList<StoredEvent>> All(Guid aggregateId);
    }
}