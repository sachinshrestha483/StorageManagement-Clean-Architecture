using StorageManagement.Core.Application.Services.Abstractions;
using StorageManagement.Core.Domain.Common.Abstractions;
using StorageManagement.Core.Domain.Common.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Core.Application.Services.Implementations
{
    public class AuditService<T> : IAuditService<T> where T : BaseAuditableEntity
    {
        public void updateAuditPropertiesOnEntityCreate(IAuditableEntity auditableEntity, string userName)
        {
            auditableEntity.CreatedBy = userName;
            auditableEntity.CreatedDate = DateTimeOffset.Now;
            auditableEntity.UpdatedBy = userName;
            auditableEntity.UpdatedDate = DateTimeOffset.Now;
        }

        public void updateAuditPropertiesOnEntityUpdate(IAuditableEntity auditableEntity, string userName)
        {
            auditableEntity.UpdatedBy = userName;
            auditableEntity.UpdatedDate = DateTimeOffset.Now;
        }
    }
}
