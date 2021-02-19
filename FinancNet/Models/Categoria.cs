using FinancNet.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinancNet.Models
{
    public class Categoria : EntityBase
    {
        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Tipo { get; set; }

        public long? PaiId { get; set; }

        [JsonIgnore]
        public virtual Categoria Pai { get; set; }

        [JsonIgnore]
        public virtual List<Categoria> Filhos { get; set; }
    }
}
