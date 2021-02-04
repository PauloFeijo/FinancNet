using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinancNet.Models
{
    public class Categoria : Entity
    {
        [Required]
        public string descricao { get; set; }

        [Required]
        public string tipo { get; set; }

        public long? paiId { get; set; }

        [JsonIgnore]
        public virtual Categoria pai { get; set; }

        [JsonIgnore]
        public virtual List<Categoria> filhos { get; set; }
    }
}
