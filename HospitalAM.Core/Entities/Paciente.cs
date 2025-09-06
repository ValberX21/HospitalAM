using HospitalAM.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAM.Core.Entities
{
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPaciente { get; set; }

        // Dados pessoais
        [Required, MaxLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        public string Nome { get; set; } = string.Empty;

        // CPF sem máscara: 11 dígitos
        [Required, StringLength(11)]
        [Column(TypeName = "char(11)")]
        public string CPF { get; set; } = string.Empty;

        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        // 'M', 'F' ou 'O'
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

        // Saúde (opcionais)
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? PlanoSaude { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string? NumeroCarteiraPlano { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Ativo { get; set; } = true;

        // Relacionamento (FK)
        [Required]
        [Column(TypeName = "int")]
        public int IdEmpresa { get; set; }
        public TipoEmpresa? Empresa { get; set; }

        // Navegação reversa (opcional): 1:1 com Usuario quando TipoUsuario = Paciente
        public TipoUsuario? Usuario { get; set; }

        public ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();

    }
}
