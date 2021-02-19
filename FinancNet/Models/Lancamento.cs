﻿using FinancNet.Models.Base;
using System;

namespace FinancNet.Models
{
    public class Lancamento : EntityBase
    {
        public DateTime Data { get; set; }

        public string Tipo { get; set; }

        public string Descricao { get; set; }

        public double Valor { get; set; }

        public long ContaId { get; set; }
        public virtual Conta Conta { get; set; }

        public long CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }        
    }
}
