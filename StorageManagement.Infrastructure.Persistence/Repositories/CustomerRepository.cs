using StorageManagement.Core.Application.Abstractions;
using StorageManagement.Core.Domain.Entities;
using StorageManagement.Infrastructure.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Customer customer)
        {
            _db.Customers.Update(customer);
        }
    }
}
