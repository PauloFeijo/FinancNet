using FinancNet.Entities.Base;
using FinancNet.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinancNet.Entities
{
    public class Entry : EntityBase
    {
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

        public virtual Account Account { get; set; }

        public virtual Category Category { get; set; }
    }
}
