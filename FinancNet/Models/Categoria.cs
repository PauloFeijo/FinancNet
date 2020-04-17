using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancNet.Models
{
    public class Categoria
    {
        public long id { get; set; }

        [Required]
        public string descricao { get; set; }

        [Required]
        public string tipo { get; set; }

    }
}
