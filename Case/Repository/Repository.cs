using Case.DatabaseContext;
using Case.Entity.Base;
using Case.Repository.Interface;
using System.Linq.Expressions;

namespace Case.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region Fields
        /// <summary>
        /// Veritabanı bağlamını temsil eden değişken
        /// </summary>
        private readonly Context _context;
        #endregion
        #region Ctor
        public Repository(Context context)
        {
            _context = context;
        }
        #endregion
        #region Methods
        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<T> GetAll() => _context.Set<T>();

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate) => _context.Set<T>().Where(predicate);
        #endregion
    }
}
