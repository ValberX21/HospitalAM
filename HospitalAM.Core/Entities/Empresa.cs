using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAM.Core.Entities
{
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpresa { get; set; }

        [Required, MaxLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        public string Nome { get; set; } = string.Empty;

        // Opcional no início do projeto
        [StringLength(14)]
        [Column(TypeName = "char(14)")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "bit")]
        public bool Ativa { get; set; } = true;

        [Column(TypeName = "datetime2")]
        public DateTime CriadaEm { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime2")]
        public DateTime? AtualizadaEm { get; set; }

        // Navegação
        public ICollection<Hospital> Hospitais { get; set; } = new List<Hospital>();
    }
}
