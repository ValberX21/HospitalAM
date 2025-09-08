using HospitalAM.Core.Entities;

namespace HospitalAM.Core.Interfaces.Repository
{
    public interface IHospitalRepository : IBaseCRUDRepository<Hospital>
    {
        Task<IEnumerable<Hospital>> GeAll(CancellationToken ct = default);
    }
}
