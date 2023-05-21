using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Equinox.Domain.Models;
using NetDevPack.Data;

namespace Equinox.Domain.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<Customer> GetByEmail(string email);

    }
}