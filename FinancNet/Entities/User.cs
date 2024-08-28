using System.ComponentModel.DataAnnotations;

namespace FinancNet.Entities
{
    public class User
    {
        [Key]
        [Required]
        [StringLength(15)]
        public string Login { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public static string LoggedUser { get; set; }
    }
}
