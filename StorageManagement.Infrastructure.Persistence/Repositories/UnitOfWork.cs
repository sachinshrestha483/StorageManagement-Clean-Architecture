using StorageManagement.Core.Application.Abstractions;
using StorageManagement.Infrastructure.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IGateEntryRepository GateEntryRepository { get; private set; }
        public ICustomerRepository CustomerRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            GateEntryRepository = new GateEntryRepository(_db);
            CustomerRepository = new CustomerRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
