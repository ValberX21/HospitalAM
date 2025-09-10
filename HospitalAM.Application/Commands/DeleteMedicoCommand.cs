using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Application.Commands
{
    public record DeleteMedicoCommand(int idMedico) : IRequest<bool>
    {
    }
}
