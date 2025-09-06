using HospitalAM.Core.Entities;
using HospitalAM.Core.Interfaces.Repository;

namespace HospitalAM.Infrastructure.Repository
{
    public class MedicoRepository : IBaseCRUDRepository<Medico>
    {
        public async Task AddAsync(Medico entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Medico>> GetAll(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Medico?> GetByIDAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Medico entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
