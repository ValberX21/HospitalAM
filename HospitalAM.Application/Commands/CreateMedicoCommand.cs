using HospitalAM.Application.ViewModel;
using HospitalAM.Core.Entities;
using MediatR;
using System.Text.RegularExpressions;

namespace HospitalAM.Application.Commands
{
    public class CreateMedicoCommand :IRequest<int>
    {
        public int IdMedico { get; init; }
        public int IdHospital { get; init; }
        public string Nome { get; init; } = string.Empty;
        public string CPF { get; init; } = string.Empty;
        public DateTime? DataNascimento { get; init; }
        public string Genero { get; init; } = "O";
        public string Email { get; init; } = string.Empty;
        public string? Telefone { get; init; }
        public string? Endereco { get; init; }
        public string CRM { get; init; } = string.Empty;
        public string? Especialidade { get; init; }
        public bool Ativo { get; init; } = true;
        public int IdEmpresa { get; init; }

        private static string OnlyDigits(string? s) =>
            string.IsNullOrWhiteSpace(s) ? string.Empty : Regex.Replace(s, "[^0-9]", "");

        public static CreateMedicoCommand FromViewModel(MedicoViewModel vm) => new()
        {
            IdMedico =  vm.IdMedico,
            IdHospital = vm.IdHospital,
            Nome = vm.Nome?.Trim() ?? string.Empty,
            CPF = OnlyDigits(vm.CPF),                 // garante 11 dígitos
            DataNascimento = vm.DataNascimento,
            Genero = (vm.Genero ?? "O").Trim().ToUpper(),// "M"|"F"|"O"
            Email = vm.Email?.Trim() ?? string.Empty,
            Telefone = vm.Telefone?.Trim(),
            Endereco = vm.Endereco?.Trim(),
            CRM = vm.CRM?.Trim() ?? string.Empty,
            Especialidade = vm.Especialidade?.Trim(),
            Ativo = vm.Ativo,
            IdEmpresa = vm.IdEmpresa
        };

        public Medico ToEntity() => new()
        {
            IdMedico = IdMedico,
            IdHospital = IdHospital,
            Nome = Nome,
            CPF = CPF,
            DataNascimento = DataNascimento,
            Genero = Genero,
            Email = Email,
            Telefone = Telefone,
            Endereco = Endereco,
            CRM = CRM,
            Especialidade = Especialidade,
            Ativo = Ativo,
            IdEmpresa = IdEmpresa
        };
    }
}
