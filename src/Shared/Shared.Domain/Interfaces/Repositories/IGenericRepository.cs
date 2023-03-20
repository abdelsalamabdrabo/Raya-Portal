using Shared.Domain.Entities;
using System.Linq.Expressions;

namespace Shared.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id, string? includeProperties = null);
        Task<T> Get(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task Add(T entity);
        void Remove(T entity);
    }
}
