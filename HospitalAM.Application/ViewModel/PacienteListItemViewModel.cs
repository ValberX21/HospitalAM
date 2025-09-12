namespace HospitalAM.Application.ViewModel
{
    public class PacienteListItemViewModel
    {
        public int IdPaciente { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public string? EmpresaNome { get; set; }
        public string? PlanoSaude { get; set; }
        public bool Ativo { get; set; }
    }
}
