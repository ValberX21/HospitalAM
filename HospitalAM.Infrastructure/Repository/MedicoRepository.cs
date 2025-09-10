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

        public async Task<int> CountAsync()
        {
            return await _context.Medico.CountAsync();
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            Medico medico = await _context.Medico.FindAsync(id);

            if (medico != null)
            {
                 _context.Medico.Remove(medico);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            else
            {               
                return false;
            }               
        }

        public async Task<Medico?> GetByIDAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Medico>> GetPages(int page, int pageSize, CancellationToken ct = default)
        {
            return await _context.Medico
                          .AsNoTracking()
                          .OrderBy(m => m.IdMedico)
                          .Skip((page - 1) * pageSize)
                          .Take(pageSize)
                          .ToListAsync(ct);

        }

        public async Task UpdateAsync(Medico entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
