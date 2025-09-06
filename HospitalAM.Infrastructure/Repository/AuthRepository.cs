using HospitalAM.Core.Entities;
using HospitalAM.Core.Interfaces.Repository;
using HospitalAM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalAM.Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context; 

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Login?> GetByEmailAsync(string email, CancellationToken ct)
        {
            return await _context.Login.SingleOrDefaultAsync(e => e.Email == email, ct);
        }
    }
}
