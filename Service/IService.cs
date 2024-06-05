namespace Service
{
    public interface IService<T> where T : class
    {
        Task CreateAsync(T entity, CancellationToken cancellationToken);
        Task<T> GetByIdAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}