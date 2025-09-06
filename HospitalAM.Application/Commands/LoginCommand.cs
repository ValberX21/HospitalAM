using MediatR;

namespace HospitalAM.Application.Commands
{
    public sealed record LoginCommand(string Email, string Password, bool RememberMe): IRequest<LoginResult>;
   
}
