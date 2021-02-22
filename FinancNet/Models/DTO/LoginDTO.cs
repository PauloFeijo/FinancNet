using FinancNet.Models.DTO.Base;
using System.ComponentModel.DataAnnotations;

namespace FinancNet.Models
{
    public class LoginDTO : DTOBase
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

        public static explicit operator LoginDTO(Usuario usuario)
        {
            return new LoginDTO()
            {
                Login = usuario.Login,
                Senha = usuario.Senha,
            };
        }
    }
}
