namespace HospitalAM.Core.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
