using HospitalAM.Core.Entities;
using HospitalAM.Core.Interfaces.Repository;
using HospitalAM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HospitalAM.Infrastructure.Repository
{
    public class HospitalRepository : IBaseCRUDRepository<Hospital>
    {
        private readonly ApplicationDbContext _context;

        public HospitalRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Hospital>> GeAll(CancellationToken ct = default)
        {
            return _context.Hospital.AsNoTracking().ToList();
        }

        public Task AddAsync(Hospital entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<Hospital?> GetByIDAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Hospital>> GetPages(int page, int pageSize, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Hospital entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
