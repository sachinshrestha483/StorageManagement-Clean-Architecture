using StorageManagement.Core.Application.Abstractions;
using StorageManagement.Core.Application.Services.Abstractions;
using StorageManagement.Core.Application.Services.Implementations;
using StorageManagement.Core.Domain.Entities;
using StorageManagement.Infrastructure.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Infrastructure.Persistence.Repositories
{
    public class GateEntryRepository : Repository<GateEntry>, IGateEntryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IAuditService<GateEntry> _auditService= new AuditService<GateEntry>();

        public GateEntryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(GateEntry gateEntry,string userName)
        {
            _auditService.updateAuditPropertiesOnEntityUpdate(gateEntry,userName);
            _db.GateEntries.Update(gateEntry);
        }
    }
}
