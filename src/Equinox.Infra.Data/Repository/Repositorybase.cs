using Equinox.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Infra.Data.Repository
{
    public abstract class Repositorybase<T> : IRepositoryBase<T> where T : class
    {
        private DbContext _ctx;
        protected Repositorybase(DbContext ctx) {
            _ctx = ctx;
        }
        public void Add(T customer)
        {
            _ctx.Set<T>().Add(customer);
        }

        public void Dispose()
        {
            _ctx.Dispose(); 
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _ctx.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        public List<T> FilterByPredicate(Func<T,bool> predicate)
        {
            return  _ctx.Set<T>().Where(predicate).ToList();
        }

        public void Remove(T customer)
        {
            _ctx.Remove(customer);
        }

        public void Update(T customer)
        {
            _ctx.Update(customer);
        }
    }
}
