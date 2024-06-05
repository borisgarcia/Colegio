namespace Aplication.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken);
        Task<T> GetById(CancellationToken cancellationToken, params object[] keyValues);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
