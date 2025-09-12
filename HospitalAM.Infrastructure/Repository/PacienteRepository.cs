using HospitalAM.Core.Entities;
using HospitalAM.Core.Interfaces.Repository;
using HospitalAM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Infrastructure.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ApplicationDbContext _context;

        public PacienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Paciente entity, CancellationToken ct = default)
        {
            var paciente = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.IdPaciente;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Paciente.CountAsync();
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Paciente?> GetByIDAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Paciente>> GetPages(int page, int pageSize, CancellationToken ct = default)
        {
            var total = await _context.Paciente.CountAsync(ct);
            var totalPages = Math.Max(1, (int)Math.Ceiling(total / (double)pageSize));

            if (page < 1) page = 1;
            if (page > totalPages) page = totalPages;

            var skip = (page - 1) * pageSize; 

            return await _context.Paciente
                .AsNoTracking()
                .OrderBy(p => p.IdPaciente)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync(ct);
        }

        public async Task<int> UpdateAsync(Paciente entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
