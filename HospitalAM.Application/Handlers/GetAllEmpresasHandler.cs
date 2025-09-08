using HospitalAM.Application.Queries;
using HospitalAM.Core.Entities;
using HospitalAM.Core.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Application.Handlers
{
    public class GetAllEmpresasHandler : IRequestHandler<GetAllEmpresasQuery, List<Empresa>>
    {
        private readonly IEmpresaRepository _empresaRepository;

        public GetAllEmpresasHandler(IEmpresaRepository empresaRepository)
            => _empresaRepository = empresaRepository;

        public async Task<List<Empresa>> Handle(GetAllEmpresasQuery request, CancellationToken ct)
        {
            var list = new List<Empresa>();

            if (request.empresaId is > 0)
            {
                var one = await _empresaRepository.GetByIDAsync(request.empresaId.Value, ct);
                if (one is not null) list.Add(one);
            }
            else
            {
                var all = await _empresaRepository.GeAll(ct);
                if (all is not null) list = all.ToList();
            }

            return list;
        }
    }
}
