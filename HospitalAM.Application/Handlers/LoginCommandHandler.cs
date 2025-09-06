using HospitalAM.Application.Commands;
using HospitalAM.Core.Entities;
using HospitalAM.Core.Interfaces;
using HospitalAM.Core.Interfaces.Services;
using MediatR;

namespace HospitalAM.Application.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        string jwtToken = string.Empty;
        
        private readonly IAuthService _auth;
        public LoginCommandHandler(IAuthService auth) => _auth = auth;

        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken ct)
        {
            ValidaUsuario ok = await _auth.ValidateAsync(request.Email, request.Password, ct);
            if (!ok.validAcess) return new LoginResult(false, jwtToken, Message: "Invalid credentials");


            var jwt = await _auth.GenerateJwtAsync(request.Email, ct);
            return new LoginResult(true, jwtToken: jwt, " ", ok.tipoUsuario);
        }
    }
}
