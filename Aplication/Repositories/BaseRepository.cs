using Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly ColegioDataContext _dataContext;
        public BaseRepository(ColegioDataContext context) 
        {
            _dataContext = context;        
        }

        public Task<T> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dataContext.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public Task<T> GetById(CancellationToken cancellationToken, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
