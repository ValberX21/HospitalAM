using HospitalAM.Application.Queries;
using HospitalAM.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalAM.Presentation.Helper
{
    public class GetDrops
    {
        private readonly IMediator _mediator;
        
        public GetDrops(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<SelectListItem>> GetHospitaisSelectAsync(int? hospitalId = null)
        {
            List<Hospital> hospitais = await _mediator.Send(new GetAllHospitaisQuery(hospitalId));

            if (hospitais == null || hospitais.Count == 0)
                return Enumerable.Empty<SelectListItem>();

            return hospitais.Select(h => new SelectListItem
            {
                Value = h.IdHospital.ToString(),
                Text = h.Nome,
                Selected = (hospitalId.HasValue && h.IdHospital == hospitalId.Value)
            });
        }

        public async Task<IEnumerable<SelectListItem>> GetEmpresas(int? empresaId = null)
        {
            List<Empresa> empresas = await _mediator.Send(new GetAllEmpresasQuery(empresaId));

            if (empresas == null || empresas.Count == 0)
                return Enumerable.Empty<SelectListItem>();

            return empresas.Select(h => new SelectListItem
            {
                Value = h.IdEmpresa.ToString(),
                Text = h.Nome,
                Selected = (empresaId.HasValue && h.IdEmpresa == empresaId.Value)
            });
        }
    }
}
