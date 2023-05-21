using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using Equinox.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace Equinox.Infra.Data.Repository
{
    public class CustomerRepository : Repositorybase<Customer>, ICustomerRepository
    {
        protected readonly EquinoxContext Db;
        protected readonly DbSet<Customer> DbSet;

        public CustomerRepository(EquinoxContext context) : base(context) 
        {
            Db = context;
            DbSet = Db.Set<Customer>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Customer> GetByEmail(string email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
