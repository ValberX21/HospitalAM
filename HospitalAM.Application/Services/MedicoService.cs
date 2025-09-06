using HospitalAM.Core.Entities;
using HospitalAM.Core.Interfaces.Services;

namespace HospitalAM.Application.Services
{
    public  class MedicoService : IBaseCRUDService<Medico>
    {
        public async Task AddAsync(Medico entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }    

        public async Task<Medico?> GetByIDAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Medico>> GetPagedAsync(int page, int pageSize, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Medico entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
