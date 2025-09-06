using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAM.Core.Entities
{
    public class Hospital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHospital { get; set; }

        [Required, MaxLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(14)]
        [Column(TypeName = "char(14)")]
        public string? CNPJ { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string? Endereco { get; set; }

        [Column(TypeName = "bit")]
        public bool Ativo { get; set; } = true;

        // FK → Empresa (opcional se não for multiempresa)
        public int? IdEmpresa { get; set; }
        [ForeignKey(nameof(IdEmpresa))]
        public Empresa? Empresa { get; set; }

        public ICollection<Medico> Medicos { get; set; } = new List<Medico>();

    }
}
