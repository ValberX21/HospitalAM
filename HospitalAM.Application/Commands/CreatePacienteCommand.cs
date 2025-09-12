using HospitalAM.Application.ViewModel;
using HospitalAM.Core.Entities;
using MediatR;
using System.Text.RegularExpressions;

namespace HospitalAM.Application.Commands
{
    public class CreatePacienteCommand : IRequest<int>
    {
        public int IdPaciente { get; init; }
        public int IdEmpresa { get; init; }
        public string Nome { get; init; } = string.Empty;
        public string CPF { get; init; } = string.Empty;
        public DateTime? DataNascimento { get; init; }
        /// <summary>M, F, or O</summary>
        public string Genero { get; init; } = "O";
        public string Email { get; init; } = string.Empty;
        public string? Telefone { get; init; }
        public string? Endereco { get; init; }
        public string? PlanoSaude { get; init; }
        public string? NumeroCarteiraPlano { get; init; }
        public bool Ativo { get; init; } = true;

        private static string OnlyDigits(string? s) =>
            string.IsNullOrWhiteSpace(s) ? string.Empty : Regex.Replace(s, "[^0-9]", "");

        private static string? NullIfEmpty(string? s)
        {
            var t = s?.Trim();
            return string.IsNullOrWhiteSpace(t) ? null : t;
        }

        /// <summary>
        /// Builds a CreatePacienteCommand from the ViewModel (sanitizes CPF/Telefone, trims strings).
        /// </summary>
        public static CreatePacienteCommand FromViewModel(PacienteViewModel vm) => new()
        {
            IdPaciente = vm.IdPaciente,
            IdEmpresa = vm.IdEmpresa,
            Nome = (vm.Nome ?? string.Empty).Trim(),
            CPF = OnlyDigits(vm.CPF),
            DataNascimento = vm.DataNascimento,
            Genero = string.IsNullOrWhiteSpace(vm.Genero) ? "O" : vm.Genero.Trim().Substring(0, 1).ToUpper(),
            Email = (vm.Email ?? string.Empty).Trim(),
            Telefone = NullIfEmpty(OnlyDigits(vm.Telefone)),
            Endereco = NullIfEmpty(vm.Endereco),
            PlanoSaude = NullIfEmpty(vm.PlanoSaude),
            NumeroCarteiraPlano = NullIfEmpty(vm.NumeroCarteiraPlano),
            Ativo = vm.Ativo
        };

        /// <summary>
        /// Maps this command into the Paciente entity.
        /// </summary>
        public Paciente ToEntity() => new()
        {
            IdPaciente = IdPaciente,
            IdEmpresa = IdEmpresa,
            Nome = Nome,
            CPF = CPF,                 // already digits-only
            DataNascimento = DataNascimento,
            Genero = Genero,              // "M" | "F" | "O"
            Email = Email,
            Telefone = Telefone,
            Endereco = Endereco,
            PlanoSaude = PlanoSaude,
            NumeroCarteiraPlano = NumeroCarteiraPlano,
            Ativo = Ativo
        };
    }
}
