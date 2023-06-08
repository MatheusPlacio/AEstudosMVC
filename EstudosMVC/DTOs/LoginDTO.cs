using System.ComponentModel.DataAnnotations;

namespace AEstudosMVC.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
