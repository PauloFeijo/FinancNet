using FinancNet.Dtos.Base;
using FinancNet.Entities;
using System.ComponentModel.DataAnnotations;

namespace FinancNet.Dtos
{
    public class LoginDTO : DTOBase
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public static explicit operator LoginDTO(User user)
        {
            return new LoginDTO()
            {
                Login = user.Login,
                Password = user.Password,
            };
        }
    }
}
