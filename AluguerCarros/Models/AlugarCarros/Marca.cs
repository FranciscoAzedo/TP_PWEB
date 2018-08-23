using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AluguerCarros.Models.AlugarCarros
{
    public class Marca
    {
        [Key]
        public int MarcaID { get; set; }
        public string Nome { get; set; }
    }
}