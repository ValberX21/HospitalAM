namespace HospitalAM.Presentation.ViewModel
{
    public class MedicoListItemViewModel
    {
        public int IdMedico { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CRM { get; set; } = string.Empty;
        public string? Especialidade { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public string? HospitalNome { get; set; }
    }
}
