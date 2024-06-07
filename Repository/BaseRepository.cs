using Domain.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly ColegioDataContext _dataContext;
        public BaseRepository(ColegioDataContext context) 
        {
            _dataContext = context;        
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken)
        {
            await _dataContext.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            var entry = await GetByIdAsync(cancellationToken, keyValues);
            
            if(entry != null)
            {
                _dataContext.Remove(entry);
            }
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dataContext.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> FilterAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dataContext.Set<T>().AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return await _dataContext.Set<T>().FindAsync(keyValues, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public void UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            var entry = _dataContext.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
