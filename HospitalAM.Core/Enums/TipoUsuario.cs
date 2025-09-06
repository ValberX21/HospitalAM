using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Core.Enums
{
    public enum TipoUsuario : byte
    {
        Nenhum = 0, 
        Tecnico = 1,
        Medico = 2,
        Paciente = 3
    }
}
