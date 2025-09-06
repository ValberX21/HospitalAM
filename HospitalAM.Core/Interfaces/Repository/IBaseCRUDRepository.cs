namespace HospitalAM.Core.Interfaces.Repository
{
    public interface IBaseCRUDRepository<T> where T : class
    {
        Task AddAsync(T entity, CancellationToken ct = default);
        Task UpdateAsync(T entity, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<T>> GetAll(CancellationToken ct = default);
        Task<T?> GetByIDAsync(int id, CancellationToken ct = default);

    }
}
