using System.ComponentModel.DataAnnotations;

namespace FinancNet.Models.Base
{
    public abstract class EntityBase       
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Usuario { get; set; }
    }
}
