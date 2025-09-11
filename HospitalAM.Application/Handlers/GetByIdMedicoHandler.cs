using HospitalAM.Application.Commands;
using HospitalAM.Application.ViewModel;
using HospitalAM.Core.Entities;
using HospitalAM.Core.Interfaces.Repository;
using MediatR;

namespace HospitalAM.Application.Handlers
{
    public class GetByIdMedicoHandler : IRequestHandler<GetByIdMedicosCommand, MedicoViewModel>
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IHospitalRepository _hospitalRepository;

        public GetByIdMedicoHandler(IMedicoRepository medicoRepository, IHospitalRepository hospitalRepository)
        {
            _medicoRepository = medicoRepository;   
            _hospitalRepository = hospitalRepository;
        }

        public async Task<MedicoViewModel> Handle(GetByIdMedicosCommand request, CancellationToken cancellationToken)
        {
            Medico? medico  = await _medicoRepository.GetByIDAsync(request.idMedico, cancellationToken);

            var hospitais = await _hospitalRepository.GeAll();

            if (medico != null)
            {
                return new MedicoViewModel
                {
                    IdMedico = medico.IdMedico,
                    Nome = medico.Nome,
                    CRM = medico.CRM,
                    Especialidade = medico.Especialidade,
                    Email = medico.Email,
                    Ativo = medico.Ativo,
                    Endereco =  medico.Endereco,
                    CPF =  medico.CPF,
                    DataNascimento =  medico.DataNascimento,
                    Telefone =  medico.Telefone,
                    IdEmpresa = medico.IdEmpresa,
                    IdHospital = medico.IdHospital
                };
            }
            else
            {
                return null;
            }



        }
    }
}
