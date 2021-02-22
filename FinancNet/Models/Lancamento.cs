using FinancNet.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinancNet.Models
{
    public class Lancamento : EntityBase
    {
        [Required]
        public DateTime Data { get; set; }

        [StringLength(10)]
        public string Tipo { get; set; }

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Required]
        public double Valor { get; set; }

        [Required]
        public long ContaId { get; set; }

        [Required]
        public long CategoriaId { get; set; }

        public virtual Conta Conta { get; set; }

        public virtual Categoria Categoria { get; set; }        
    }
}
