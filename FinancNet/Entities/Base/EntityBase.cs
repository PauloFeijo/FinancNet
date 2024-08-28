using System.ComponentModel.DataAnnotations;

namespace FinancNet.Entities.Base
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; set; }

        [StringLength(15)]
        public string User { get; set; }
    }
}
