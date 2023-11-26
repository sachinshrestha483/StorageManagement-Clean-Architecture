using StorageManagement.Core.Domain.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Core.Domain.Common.Primitives
{
    public abstract class BaseAuditableEntity : IAuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}
