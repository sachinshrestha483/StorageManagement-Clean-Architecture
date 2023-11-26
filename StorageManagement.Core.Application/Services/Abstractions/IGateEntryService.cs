using StorageManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Core.Application.Services.Abstractions
{
    public interface IGateEntryService
    {
        IEnumerable<GateEntry> GetAll();
        void Create(GateEntry gateEntry, string userName);
        void Update(GateEntry gateEntry, string userName);
        GateEntry GetById(int id);
        bool Delete(int id);
        void Save();
    }
}
