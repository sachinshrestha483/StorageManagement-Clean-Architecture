using StorageManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Core.Application.Abstractions
{
    public interface IGateEntryRepository : IRepository<GateEntry>
    {
        void Update(GateEntry gateEntry, string userName);
    }
}
