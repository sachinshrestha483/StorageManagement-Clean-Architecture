using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using StorageManagement.Core.Application.Abstractions;
using StorageManagement.Core.Application.Services.Abstractions;
using StorageManagement.Core.Application.Services.Implementations;
using StorageManagement.Core.Domain.Common.Primitives;
using StorageManagement.Infrastructure.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseAuditableEntity
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        private readonly IAuditService<T> _auditService = new AuditService<T>();
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }
        public void Add(T entity, string userName)
        {
            _auditService.updateAuditPropertiesOnEntityCreate(entity, userName);

            dbSet.Add(entity);
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            return dbSet.Any(filter);
        }

        public T Get(Expression<Func<T, bool>> filter, List<string> includeProperties, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;
            }
            else
            {
                query = dbSet.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null && includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);

                }
            }

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(List<string> includeProperties, Expression<Func<T, bool>>? filter = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;
            }
            else
            {
                query = dbSet.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null && includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }

}
