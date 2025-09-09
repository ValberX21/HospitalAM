using HospitalAM.Core.Entities;
using HospitalAM.Core.Interfaces.Repository;
using HospitalAM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalAM.Infrastructure.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Medico entity, CancellationToken ct = default)
        {
           var medico =  await _context.Medico.AddAsync(entity);
           await _context.SaveChangesAsync(ct);    

            return entity.IdMedico;

        }

        public Task DeleteAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<Medico?> GetByIDAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Medico>> GetPages(int page, int pageSize, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Medico entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
