using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<(bool ok, string? jwt, string? error)> LoginAsync(string email, string password, bool rememberMe, CancellationToken ct);
        Task<ValidaUsuario> ValidateAsync(string email, string password, CancellationToken ct = default);
        Task<string> GenerateJwtAsync(string email, CancellationToken ct = default);
    }
}
