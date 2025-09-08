using HospitalAM.Core.Entities;

namespace HospitalAM.Core.Interfaces.Repository
{
    public interface IEmpresaRepository : IBaseCRUDRepository<Empresa>
    {
        Task<IEnumerable<Empresa>> GeAll(CancellationToken ct = default);
    }
}
