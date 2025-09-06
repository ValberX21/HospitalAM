using HospitalAM.Core.Entities;
using HospitalAM.Core.Enums;
using HospitalAM.Core.Interfaces;
using HospitalAM.Core.Interfaces.Repository;
using HospitalAM.Core.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalAM.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _IAuthRepository;
        private readonly IPasswordHasher<Login> _hasher;
        private readonly JwtOptions _jwt;

        public AuthService(IAuthRepository authRepository,
                           IPasswordHasher<Login> hasher,
                           IOptions<JwtOptions> jwtOptions)
        {
            _IAuthRepository = authRepository;      
            _hasher = hasher;
            _jwt = jwtOptions.Value;    
        }

        public async Task<string> GenerateJwtAsync(string email, CancellationToken ct = default)
        {
            var normalized = email.Trim().ToLower();

            Login? user = await _IAuthRepository.GetByEmailAsync(normalized, ct);

            if (user is null || !user.Ativo) return string.Empty;

            var now = DateTime.UtcNow;

            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.IdLogin.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Usuario),
            new Claim(ClaimTypes.NameIdentifier, user.IdLogin.ToString()),
            new Claim(ClaimTypes.Name, user.Usuario),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Tipo.ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_jwt.ExpirationMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<(bool ok, string? jwt, string? error)> LoginAsync(string email, string password, bool rememberMe, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<ValidaUsuario> ValidateAsync(string email, string password, CancellationToken ct = default)
        {
            ValidaUsuario userValid = new ValidaUsuario();  

            var normalized = email.Trim().ToLower();

            Login? user = await _IAuthRepository.GetByEmailAsync(normalized, ct);

            if (user is null || !user.Ativo)
            {
                userValid.validAcess = false;  
                return userValid;
            } 

            var result = _hasher.VerifyHashedPassword(user, user.SenhaHash, password);

            if (result == PasswordVerifyResult.Failed)
            {
                userValid.validAcess = false;
                return userValid;
            }

            userValid.tipoUsuario = user.Tipo;
            userValid.validAcess = true;
            return userValid;

            //// Optional: upgrade hash if algorithm/strength changed
            //if (result == PasswordVerifyResult.SuccessRehashNeeded)
            //{
            //    user.SenhaHash = _hasher.HashPassword(user, password);
            //    await _db.SaveChangesAsync(ct);
            //}

            //user.UltimoAcesso = DateTime.UtcNow;
            //await _db.SaveChangesAsync(ct);

        }
    }
}
