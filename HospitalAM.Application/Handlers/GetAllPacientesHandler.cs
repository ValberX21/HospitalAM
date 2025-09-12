using HospitalAM.Application.DTOs;
using HospitalAM.Application.Queries;
using HospitalAM.Application.ViewModel;
using HospitalAM.Core.Entities;
using HospitalAM.Core.Interfaces.Repository;
using MediatR;

namespace HospitalAM.Application.Handlers
{
    public class GetAllPacientesHandler : IRequestHandler<GetAllPacientesQuery, PagedResult<PacienteListItemViewModel>>
    {
        private readonly IPacienteRepository _pacienteRepository;

        public GetAllPacientesHandler(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<PagedResult<PacienteListItemViewModel>> Handle(GetAllPacientesQuery request, CancellationToken cancellationToken)
        {
            int totalPacientes = await _pacienteRepository.CountAsync();

            IEnumerable<Paciente> pacientes = await _pacienteRepository.GetPages(request.Page, request.PageSize, cancellationToken);

            var paci = pacientes.Select(p => new PacienteListItemViewModel
            {
                IdPaciente = p.IdPaciente,
                Nome = p.Nome,
                CPF = p.CPF,          // or format if you prefer
                Email = p.Email,
                Telefone = p.Telefone,
                EmpresaNome = p.Empresa != null ? p.Empresa.Value.ToString() : null,  // adjust .Nome to your property
                PlanoSaude = p.PlanoSaude,
                Ativo = p.Ativo
            }).ToList();

            return new PagedResult<PacienteListItemViewModel>(
               Items: paci,
               TotalItems: totalPacientes,
               Page: request.Page,
               PageSize: request.PageSize
           );
        }
    }
}
