using FinancNet.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinancNet.Entities
{
    public class Transfer : EntityBase
    {
        [Required]
        public long DebitAccountId { get; set; }

        [Required]
        public long CreditAccountId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Value { get; set; }

        public virtual Account DebitAccount { get; set; }

        public virtual Account CreditAccount { get; set; }
    }
}
