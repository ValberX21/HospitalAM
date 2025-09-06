using HospitalAM.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAM.Core.Entities
{

    public class Medico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMedico { get; set; }

        public int IdHospital { get; set; }

        // Dados pessoais
        [Required, MaxLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        public string Nome { get; set; } = string.Empty;

        // Armazene CPF sem pontuação: 11 dígitos
        [Required, StringLength(11)]
        [Column(TypeName = "char(11)")]
        public string CPF { get; set; } = string.Empty;

        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        // 'M', 'F' ou 'O' (Outro) — check no Fluent/SQL
        [Required, MaxLength(1)]
        [Column(TypeName = "char(1)")]
        public string Genero { get; set; } = "O";

        // Contato
        [Required, MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string? Telefone { get; set; }

        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string? Endereco { get; set; }

        // Profissional
        [Required, MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string CRM { get; set; } = string.Empty;

        [MaxLength(120)]
        [Column(TypeName = "nvarchar(120)")]
        public string? Especialidade { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Ativo { get; set; } = true;

        // Relacionamento (FK)
        [Required]
        [ForeignKey(nameof(Empresa))]
        [Column(TypeName = "int")]
        public int IdEmpresa { get; set; }

        public TipoEmpresa? Empresa { get; set; }

        public ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();

        public ICollection<Hospital> Hospital { get; set; } = new List<Hospital>();

    }
}
