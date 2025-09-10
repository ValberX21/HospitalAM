using HospitalAM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Core.Interfaces.Repository
{
    public interface IMedicoRepository : IBaseCRUDRepository<Medico>
    {
        Task<int> CountAsync(); 
    }
}
