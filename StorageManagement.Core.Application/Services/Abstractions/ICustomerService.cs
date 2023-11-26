using StorageManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Core.Application.Services.Abstractions
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        void Create(Customer gateEntry);
        void Update(Customer gateEntry);
        Customer GetById(int id);
        bool Delete(int id);
        void Save();
    }
}
