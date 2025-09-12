using HospitalAM.Application.Commands;
using HospitalAM.Core.Entities;
using HospitalAM.Core.Interfaces.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HospitalAM.Application.Handlers
{
    public class CreateMedicoHandler : IRequestHandler<CreateMedicoCommand, int>
    {       
        private readonly IMedicoRepository _medicoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateMedicoHandler> _logger;

        public CreateMedicoHandler(IMedicoRepository medico, IUnitOfWork @object, ILogger<CreateMedicoHandler> logger )
        {
            _medicoRepository = medico ?? throw new ArgumentNullException(nameof(medico));
            _unitOfWork = @object ?? throw new ArgumentNullException(nameof(@object));
            _logger = logger;
        }

        public async Task<int> Handle(CreateMedicoCommand request, CancellationToken cancellationToken)
        {
           
           var medico =  new Medico
           {
                IdMedico = request.IdMedico,
                IdHospital = request.IdHospital,
                Nome = request.Nome,
                CPF = NormalizeDigits(request.CPF),
                DataNascimento = request.DataNascimento,
                Genero = request.Genero,
                Email = request.Email,
                Telefone = request.Telefone,
                Endereco = request.Endereco,
                CRM = request.CRM,
                Especialidade = request.Especialidade,
                Ativo = request.Ativo,
                IdEmpresa = request.IdEmpresa
            };

            if(request.IdMedico == 0)
            {
                await _medicoRepository.AddAsync(medico);
                await _unitOfWork.CommitAsync(cancellationToken);
                return medico.IdMedico;
            }
            else
            {
                await _medicoRepository.UpdateAsync(medico);
                await _unitOfWork.CommitAsync(cancellationToken);
                return medico.IdMedico;
            }
                   
        }

        private static string NormalizeDigits(string s) =>
       string.IsNullOrWhiteSpace(s) ? string.Empty : System.Text.RegularExpressions.Regex.Replace(s, "[^0-9]", "");
    }
}
