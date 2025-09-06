using HospitalAM.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAM.Core.Entities
{
    public class Exame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdExame { get; set; }

        [Required]
        public int IdConsulta { get; set; }
        [ForeignKey(nameof(IdConsulta))]
        public Consulta Consulta { get; set; } = default!;

        [Required]
        public TipoExame Tipo { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime SolicitadoEm { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime2")]
        public DateTime? ResultadoEm { get; set; }

        [MaxLength(4000)]
        [Column(TypeName = "nvarchar(4000)")]
        public string? ResultadoTexto { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? ResultadoArquivoUrl { get; set; } // link para PDF/Imagem no Blob

        [Required]
        [MaxLength(1000)]
        [Column(TypeName = "nvarchar(1000)")]
        public string Pedido { get; set; } = string.Empty;

        // NOVO: Resultado (texto do resultado)
        [MaxLength(2000)]
        [Column(TypeName = "nvarchar(2000)")]
        public string? Resultado { get; set; }

        public StatusExame Status { get; set; } = StatusExame.Solicitado;
    }
}
