using FinancNet.Entities.Base;
using FinancNet.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinancNet.Entities
{
    public class Category : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public EntryType Type { get; set; }

        public long? ParentId { get; set; }

        [JsonIgnore]
        public virtual Category Parent { get; set; }

        [JsonIgnore]
        public virtual List<Category> Children { get; set; }
    }
}
