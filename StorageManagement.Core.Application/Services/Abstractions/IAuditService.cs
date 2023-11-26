using StorageManagement.Core.Domain.Common.Abstractions;
using StorageManagement.Core.Domain.Common.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Core.Application.Services.Abstractions
{
    public interface IAuditService<T> where T : BaseAuditableEntity
    {
        public void updateAuditPropertiesOnEntityUpdate(IAuditableEntity auditableEntity,string userName);
        public void updateAuditPropertiesOnEntityCreate(IAuditableEntity auditableEntity,string userName);

    }
}
