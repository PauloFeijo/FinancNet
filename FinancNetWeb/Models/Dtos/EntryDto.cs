using FinancNetWeb.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinancNetWeb.Models.Dtos
{
    public class EntryDto
    {
        public long Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public EntryType Type { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public long AccountId { get; set; }

        [Required]
        public long CategoryId { get; set; }

        public virtual AccountDto Account { get; set; }

        public virtual CategoryDto Category { get; set; }
    }
}
