using Microsoft.EntityFrameworkCore;
using Shared.Domain.Entities;
using Shared.Domain.Interfaces.Repositories;
using Shared.Infrastructure.Context;
using System.Linq.Expressions;

namespace Shared.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MVMASTERDbContext _context;
        private DbSet<T> dbSet;
        public GenericRepository(MVMASTERDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public async Task<T> GetById(int id, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();

            IncludeProperties(ref query, includeProperties);

            var entity = await query.FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }
        public async Task<T> Get(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();

            IncludeProperties(ref query, includeProperties);

            var entity = await query.FirstOrDefaultAsync(filter);

            return entity;
        }
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();

            IncludeProperties(ref query, includeProperties);

            if (filter != null)
                query.Where(filter);

            var entities = await query.ToListAsync();

            return entities;
        }
        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public static void IncludeProperties(ref IQueryable<T> query, string? includeProperties)
        {
            if (includeProperties != null)
            {
                var Properties = includeProperties.Split(',');

                foreach (var property in Properties)
                    query.Include(property);
            }
        }
    }
}
