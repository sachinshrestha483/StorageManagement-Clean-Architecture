using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Core.Application.Abstractions
{
    public interface IUnitOfWork
    {
        IGateEntryRepository GateEntryRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        void Save();
    }
}
