using HospitalAM.Application.Commands;
using HospitalAM.Core.Entities;
using HospitalAM.Core.Interfaces.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace HospitalAM.Application.Handlers
{
    public class CreatePacienteHandler : IRequestHandler<CreatePacienteCommand, int>
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateMedicoHandler> _logger;

        public CreatePacienteHandler(IPacienteRepository medico, IUnitOfWork @object, ILogger<CreateMedicoHandler> logger)
        {
            _pacienteRepository = medico ?? throw new ArgumentNullException(nameof(medico));
            _unitOfWork = @object ?? throw new ArgumentNullException(nameof(@object));
            _logger = logger;
        }

        public async Task<int> Handle(CreatePacienteCommand request, CancellationToken cancellationToken)
        {
            var paciente = new Paciente
            {
                IdEmpresa = request.IdEmpresa,
                Nome = (request.Nome ?? string.Empty).Trim(),
                CPF = OnlyDigits(request.CPF),
                DataNascimento = request.DataNascimento,
                Genero = NormalizeGenero(request.Genero),
                Email = (request.Email ?? string.Empty).Trim(),
                Telefone = NullIfEmpty(OnlyDigits(request.Telefone)),
                Endereco = NullIfEmpty(request.Endereco),
                PlanoSaude = NullIfEmpty(request.PlanoSaude),
                NumeroCarteiraPlano = NullIfEmpty(request.NumeroCarteiraPlano),
                Ativo = request.Ativo
            };

            if (request.IdPaciente == 0)
            {
                await _pacienteRepository.AddAsync(paciente);
                await _unitOfWork.CommitAsync(cancellationToken);
                return paciente.IdPaciente;
            }
            else
            {
                await _pacienteRepository.UpdateAsync(paciente);
                await _unitOfWork.CommitAsync(cancellationToken);
                return paciente.IdPaciente;
            }
        }

        private static string OnlyDigits(string? s) =>
                string.IsNullOrWhiteSpace(s) ? string.Empty : Regex.Replace(s, "[^0-9]", "");

        private static string? NullIfEmpty(string? s)
        {
            var t = s?.Trim();
            return string.IsNullOrWhiteSpace(t) ? null : t;
        }

        private static string NormalizeGenero(string? g) =>
            string.IsNullOrWhiteSpace(g) ? "O" : g.Trim().Substring(0, 1).ToUpperInvariant();

    }
}
