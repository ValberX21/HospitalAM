using HospitalAM.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HospitalAM.Presentation.ViewModel
{
    public class MedicoViewModel
    {
        // ===== Form fields (create/edit) =====
        public int IdMedico { get; set; }

        [Required(ErrorMessage = "O hospital é obrigatório.")]
        public int IdHospital { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 dígitos.")]
        public string CPF { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "O gênero é obrigatório.")]
        [RegularExpression("M|F|O", ErrorMessage = "Valores permitidos: 'M', 'F' ou 'O'.")]
        public string Genero { get; set; } = "O";

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres.")]
        public string? Telefone { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo de 200 caracteres.")]
        public string? Endereco { get; set; }

        [Required(ErrorMessage = "O CRM é obrigatório.")]
        [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres.")]
        public string CRM { get; set; } = string.Empty;

        [MaxLength(120, ErrorMessage = "Máximo de 120 caracteres.")]
        public string? Especialidade { get; set; }

        public bool Ativo { get; set; } = true;

        [Required(ErrorMessage = "A empresa é obrigatória.")]
        public int IdEmpresa { get; set; }

        // ===== UI lists =====
        // For dropdown of hospitals
        public IEnumerable<SelectListItem> Hospitais { get; set; } = Enumerable.Empty<SelectListItem>();

        // ===== Filters (list/search) =====
        public string? NomeFilter { get; set; }
        public string? EspecialidadeFilter { get; set; }
        /// <summary>
        /// null = Todos, true = Apenas Ativos, false = Apenas Inativos
        /// </summary>
        public bool? AtivoFilter { get; set; }

        // ===== Results (grid/list) =====
        public IEnumerable<MedicoListItemViewModel> Medicos { get; set; } = new List<MedicoListItemViewModel>();

    }
}
