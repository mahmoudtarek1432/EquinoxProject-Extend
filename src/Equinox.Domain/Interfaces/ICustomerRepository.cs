using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Equinox.Domain.Models;
using NetDevPack.Data;

namespace Equinox.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>, IRepositoryBase<Customer>
    {
        Task<Customer> GetByEmail(string email);

    }
}