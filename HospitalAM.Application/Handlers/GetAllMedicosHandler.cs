using HospitalAM.Application.Commands;
using HospitalAM.Application.DTOs;
using HospitalAM.Application.ViewModel;
using HospitalAM.Core.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace HospitalAM.Application.Handlers
{
    public class GetAllMedicosHandler : IRequestHandler<GetAllMedicosQuery, PagedResult<MedicoListItemViewModel>>
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IHospitalRepository _hospitalRepository;
        public GetAllMedicosHandler(IMedicoRepository medicoRepository, IHospitalRepository hospitalRepository)
        {
            _medicoRepository = medicoRepository;
            _hospitalRepository = hospitalRepository;
        }

        public async  Task<PagedResult<MedicoListItemViewModel>> Handle(GetAllMedicosQuery request, CancellationToken cancellationToken)
        {
            int totalMedicos = await _medicoRepository.CountAsync();

            var medicos = await _medicoRepository.GetPages(request.Page, request.PageSize, cancellationToken);

            var hospitais = await _hospitalRepository.GeAll();

            var medi = medicos.Select(m => new MedicoListItemViewModel
            {
                IdMedico = m.IdMedico,
                Nome = m.Nome,
                CRM = m.CRM,
                Ativo = m.Ativo,
                Especialidade = m.Especialidade,
                Email = m.Email,
                HospitalNome = hospitais.FirstOrDefault(h => h.IdHospital == m.IdHospital)?.Nome ?? string.Empty
            }).ToList();

            return new PagedResult<MedicoListItemViewModel>(
                Items: medi,
                TotalItems: totalMedicos,
                Page: request.Page,
                PageSize: request.PageSize
            );
        }
    }
}
