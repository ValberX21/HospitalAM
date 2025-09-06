namespace HospitalAM.Core.Interfaces.Services
{
    public interface IBaseCRUDService<T> where T : class 
    {
        Task AddAsync(T entity, CancellationToken ct = default);
        Task UpdateAsync(T entity, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<T>> GetPagedAsync(int page, int pageSize, CancellationToken ct = default);
        Task<T?> GetByIDAsync(int id, CancellationToken ct = default);

    }
}
