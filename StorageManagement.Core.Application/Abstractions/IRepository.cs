using StorageManagement.Core.Domain.Common.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Core.Application.Abstractions
{
    public interface IRepository<T> where T : BaseAuditableEntity
    {
        IEnumerable<T> GetAll(List<string> includeProperties, Expression<Func<T, bool>>? filter = null, bool tracked = false);
        T Get(Expression<Func<T, bool>> filter, List<string> includeProperties = null, bool tracked = false);
        void Add(T entity,string userName);
        bool Any(Expression<Func<T, bool>> filter);
        void Remove(T entity);
    }
}
