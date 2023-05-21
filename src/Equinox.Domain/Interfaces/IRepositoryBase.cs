using Equinox.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Equinox.Domain.Interfaces
{
    public interface IRepositoryBase<T>
    {
        public Task<T> GetById(Guid id);

        public List<T> FilterByPredicate(Func<T, bool> predicate);

        public Task<IEnumerable<T>> GetAll();

        public void Add(T customer);

        public void Update(T customer);

        public void Remove(T customer);

        public void Dispose();
    }
}
}