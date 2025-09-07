using HospitalAM.Core.Entities;
using HospitalAM.Core.Interfaces.Repository;

namespace HospitalAM.Infrastructure.Repository
{
    public class EmpresaRepository : IBaseCRUDRepository<Empresa>
    {
        public Task AddAsync(Empresa entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Empresa>> GeAll(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<Empresa?> GetByIDAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Empresa>> GetPages(int page, int pageSize, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Empresa entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
