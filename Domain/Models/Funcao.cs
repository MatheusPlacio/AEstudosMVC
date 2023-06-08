using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class Funcao : IdentityRole<string>
    {
        public string Descricao { get; set; }
    }
}
