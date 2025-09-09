using System.ComponentModel.DataAnnotations;

namespace HospitalAM.Application.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        // Se quiser suportar "lembrar-me"
        public bool RememberMe { get; set; } = false;
    }
}
