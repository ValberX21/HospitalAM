using HospitalAM.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Application.Commands
{
    public record LoginResult(bool Success,
                              string? jwtToken = null,
                              string? Message = null,
                              TipoUsuario TipoUsuario = 0);
  
}
