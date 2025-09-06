using HospitalAM.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Core.Entities
{
    public class Prescricao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrescricao { get; set; }

        [Required]
        public int IdConsulta { get; set; }
        [ForeignKey(nameof(IdConsulta))]
        public Consulta Consulta { get; set; } = default!;

        [Required]
        public int IdMedico { get; set; } // redundante mas útil para auditoria

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DataEmissao { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "date")]
        public DateTime? ValidaAte { get; set; }

        [Required]
        [MaxLength(4000)]
        [Column(TypeName = "nvarchar(4000)")]
        public string Conteudo { get; set; } = string.Empty; // ex: "Dipirona 500mg, 1cp 8/8h por 3 dias"

        public StatusPrescricao Status { get; set; } = StatusPrescricao.Ativa;

         public ICollection<Medico> Medico { get; set; } = new List<Medico>();
    }
}
