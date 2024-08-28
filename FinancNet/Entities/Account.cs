using FinancNet.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinancNet.Entities
{
    public class Account : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(15)]
        public string Number { get; set; }

        [Required]
        public double Balance { get; set; }
    }
}
