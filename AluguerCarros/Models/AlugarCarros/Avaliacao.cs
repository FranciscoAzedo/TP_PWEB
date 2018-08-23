using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AluguerCarros.Models.AlugarCarros
{
    public class Avaliacao
    {
        [Key]
        public int AvaliacaoID { get; set; }
        public int Resultado { get; set; }
    }
}