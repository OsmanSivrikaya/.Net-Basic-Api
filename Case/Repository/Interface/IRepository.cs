using Case.Entity.Base;
using System.Linq.Expressions;

namespace Case.Repository.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> method);
        Task<T> CreateAsync(T entity);
    }
}
