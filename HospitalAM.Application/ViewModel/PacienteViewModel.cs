using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Application.ViewModel
{
    public class PacienteViewModel
    {
        // ===== Form fields (create/edit) =====
        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 dígitos.")]
        public string CPF { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "O gênero é obrigatório.")]
        [RegularExpression("M|F|O", ErrorMessage = "O gênero deve ser 'M', 'F' ou 'O'.")]
        public string Genero { get; set; } = "O";

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres.")]
        [Phone(ErrorMessage = "Número de telefone inválido.")]
        public string? Telefone { get; set; }

        [MaxLength(200)]
        public string? Endereco { get; set; }

        [MaxLength(100)]
        public string? PlanoSaude { get; set; }

        [MaxLength(30)]
        public string? NumeroCarteiraPlano { get; set; }

        [Required]
        public bool Ativo { get; set; } = true;

        [Required(ErrorMessage = "A empresa é obrigatória.")]
        public int IdEmpresa { get; set; }

        // ===== Campos auxiliares de exibição =====
        public string? NomeEmpresa { get; set; }

        // Para dropdown de empresas no filtro e no formulário
        public IEnumerable<SelectListItem> Empresas { get; set; } = Enumerable.Empty<SelectListItem>();

        // ===== Filtros da página Index =====
        public string? NomeFilter { get; set; }
        public string? CpfFilter { get; set; }
        public string? PlanoSaudeFilter { get; set; }
        public int? EmpresaFilter { get; set; }
        public bool? AtivoFilter { get; set; }

        // ===== Paginação =====
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; } = 1;
        public int TotalCount { get; set; } = 0;

        // ===== Lista para a tabela =====
        public IEnumerable<PacienteListItemViewModel>? Pacientes { get; set; }
    }
}