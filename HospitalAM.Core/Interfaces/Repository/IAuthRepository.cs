using HospitalAM.Core.Entities;

namespace HospitalAM.Core.Interfaces.Repository
{
    public interface IAuthRepository
    {
        Task<Login?> GetByEmailAsync(string email, CancellationToken ct);
    }
}
