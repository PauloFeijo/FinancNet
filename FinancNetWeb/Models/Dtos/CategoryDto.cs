using FinancNetWeb.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinancNetWeb.Models.Dtos
{
    public class CategoryDto
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public EntryType Type { get; set; }

        public long? ParentId { get; set; }
    }
}
