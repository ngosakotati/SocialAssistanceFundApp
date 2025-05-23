using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SocialAssistanceFundApp.Data;
using SocialAssistanceFundApp.Interfaces;
using System.Linq.Expressions;

namespace SocialAssistanceFundApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private SAFDbContext _dbContext;
        private const int _batchSize = 500;
        public Repository(SAFDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public virtual IEnumerable<T> GetAllPaginated(int pageNumber = 1, int pageSize = 150)
        {
            var skipNumber = (pageNumber - 1) * pageSize;
            return _dbContext.Set<T>().Skip(skipNumber).Take(pageSize).AsEnumerable();
        }

        public virtual async Task<IEnumerable<T>> GetAllAysnc()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAysncPaginated(int pageNumber = 1, int pageSize = 150)
        {
            var skipNumber = (pageNumber - 1) * pageSize;

            return await _dbContext.Set<T>().Skip(skipNumber).Take(pageSize).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual int Count()
        {
            return _dbContext.Set<T>().Count();
        }
        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public IQueryable<T> AllIncludingQueryable(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public IQueryable<T> GetSingle(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbContext.Set<T>().Where(predicate);
            return query;
        }

        public IQueryable<T> GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.Where(predicate);
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate);
        }

        public virtual void Add(T entity)
        {
            EntityEntry dbEntityEntry = _dbContext.Entry<T>(entity);
            _dbContext.Set<T>().Add(entity);
        }

        public virtual async Task BulkInsertAsync(IList<T> entities)
        {

            var entityEntryList = new List<EntityEntry>();

            for (int i = 0; i < entities.Count; i += _batchSize)
            {
                var batch = entities.Skip(i).Take(_batchSize).ToList();
                _dbContext.AddRange(batch);

                foreach (var entity in batch)
                {
                    entityEntryList.Add(_dbContext.Entry<T>(entity));
                }
                await _dbContext.SaveChangesAsync();
            }
        }

        public virtual async Task BulkUpdateAsync(IList<T> entities)
        {

            var entityEntryList = new List<EntityEntry>();

            for (int i = 0; i < entities.Count; i += _batchSize)
            {
                var batch = entities.Skip(i).Take(_batchSize).ToList();
                _dbContext.UpdateRange(batch);

                foreach (var entity in batch)
                {
                    entityEntryList.Add(_dbContext.Entry<T>(entity));
                }
                await _dbContext.SaveChangesAsync();
            }
        }

        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = _dbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _dbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
