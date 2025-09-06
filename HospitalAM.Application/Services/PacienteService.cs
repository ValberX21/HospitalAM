using HospitalAM.Core.Entities;
using HospitalAM.Core.Interfaces.Services;

namespace HospitalAM.Application.Services
{
    public class PacienteService : IBaseCRUDService<Paciente>
    {
        public async Task AddAsync(Paciente entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }


        public async Task<Paciente?> GetByIDAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Paciente>> GetPagedAsync(int page, int pageSize, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Paciente entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
