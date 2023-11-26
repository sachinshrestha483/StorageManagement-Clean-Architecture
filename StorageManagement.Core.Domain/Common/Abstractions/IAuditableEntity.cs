using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Core.Domain.Common.Abstractions
{
    public  interface IAuditableEntity
    {
        string CreatedBy { get; set; }
        DateTimeOffset? CreatedDate { get; set; }
        string UpdatedBy { get; set; }
        DateTimeOffset? UpdatedDate { get; set; }
    }
}
