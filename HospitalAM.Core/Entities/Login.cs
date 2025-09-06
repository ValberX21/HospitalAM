using HospitalAM.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAM.Core.Entities
{
    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLogin { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Usuario { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string SenhaHash { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "bit")]
        public bool Ativo { get; set; } = true;

        [Column(TypeName = "datetime2")]
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime2")]
        public DateTime? UltimoAcesso { get; set; }

        [Required]
        public TipoUsuario Tipo { get; set; }
    }
}
