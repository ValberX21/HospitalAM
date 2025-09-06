using HospitalAM.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Core.Interfaces
{
    public class ValidaUsuario
    {
        public bool validAcess { get; set; }
        public TipoUsuario tipoUsuario { get; set; }
    }
}
