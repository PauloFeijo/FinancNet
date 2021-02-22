using System.ComponentModel.DataAnnotations;

namespace FinancNet.Models.Base
{
    public abstract class EntityBase       
    {
        [Key]
        public long Id { get; set; }

        [StringLength(15)]
        public string Usuario { get; set; }
    }
}
