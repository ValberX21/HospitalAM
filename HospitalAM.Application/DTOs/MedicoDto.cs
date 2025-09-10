namespace HospitalAM.Application.DTOs
{
    public class MedicoDto
    {
        public int IdMedico { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string? Especialidade { get; set; }
        public string Email { get; set; } 
        public bool Ativo { get; set; }
        public string? HospitalNome { get; set; }
    }
}
