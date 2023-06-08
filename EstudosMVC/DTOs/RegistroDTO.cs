using System.ComponentModel.DataAnnotations;

namespace AEstudosMVC.DTOs
{
    public class RegistroDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(40, ErrorMessage = "Use menos caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Telefone { get; set; }

        public IFormFile Foto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(60, ErrorMessage = "Use menos caracteres")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(60, ErrorMessage = "Use menos caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(60, ErrorMessage = "Use menos caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme sua senha")]
        [Compare("Senha", ErrorMessage = "A senhas não conferem")]
        public string SenhaConfirmada { get; set; }
    }
}
