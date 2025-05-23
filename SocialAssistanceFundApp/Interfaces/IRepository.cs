using System.Linq.Expressions;

namespace SocialAssistanceFundApp.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> AllIncludingQueryable(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllPaginated(int pageNumber = 1, int pageSize = 150);
        Task<IEnumerable<T>> GetAllAysnc();
        Task<IEnumerable<T>> GetAllAysncPaginated(int pageNumber = 1, int pageSize = 150);
        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        int Count();
        IQueryable<T> GetSingle(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        void Add(T entity);
        Task BulkInsertAsync(IList<T> entities);
        Task BulkUpdateAsync(IList<T> entities);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
