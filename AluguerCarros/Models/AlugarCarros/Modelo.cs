using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AluguerCarros.Models.AlugarCarros
{
    public class Modelo
    {
        [Key]
        public int ModeloID { get; set; }
        public string Nome { get; set; }
        public Marca Marca { get; set; }
    }
}