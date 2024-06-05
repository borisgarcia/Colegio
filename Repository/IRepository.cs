namespace Repositories
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity, CancellationToken cancellationToken);
        Task<T> GetByIdAsync(CancellationToken cancellationToken, params object[] keyValues);
        void UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
