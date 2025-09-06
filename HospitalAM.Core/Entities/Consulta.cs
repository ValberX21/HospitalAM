using HospitalAM.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace HospitalAM.Core.Entities
{
    public class Consulta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConsulta { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DataHora { get; set; }

        [Required]
        public int IdMedico { get; set; }      // FK para Medico

        [Required]
        public int IdPaciente { get; set; }    // FK para Paciente

        public int? IdHospital { get; set; }   // Opcional
        [ForeignKey(nameof(IdHospital))]
        public Hospital? Hospital { get; set; }

        [Column(TypeName = "nvarchar(2000)")]
        public string? Diagnostico { get; set; }

        [Column(TypeName = "nvarchar(2000)")]
        public string? Observacoes { get; set; }

        public StatusConsulta Status { get; set; } = StatusConsulta.Agendada;

        // Navegação leve (sem dependência direta se estiver em outro BC/DbContext)
         public Medico? Medico { get; set; }
         public Paciente? Paciente { get; set; }

        public ICollection<Prescricao> Prescricoes { get; set; } = new List<Prescricao>();
        public ICollection<Exame> Exames { get; set; } = new List<Exame>();
    }
}
