using Equinox.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using NetDevPack.Domain;
using NetDevPack.Data;
using System.Linq.Expressions;
using System.Linq;

namespace Equinox.Domain.Interfaces
{
    public interface IRepositoryBase<T> :  IDisposable where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        public Task<IReadOnlyList<T>> GetAllAsync();

        public Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        public Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true);

        public Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true);

        public Task<T> GetByIdAsync(int id);

        public Task<T> AddAsync(T entity);

        public Task UpdateAsync(T entity);

        public Task DeleteAsync(T entity);
    }
}