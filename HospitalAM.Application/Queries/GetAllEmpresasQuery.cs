using HospitalAM.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Application.Queries
{
    public record GetAllEmpresasQuery(int? empresaId) : IRequest<List<Empresa>>
    {
    }
}
