using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AluguerCarros.Models.AlugarCarros
{
    public class CarroViewModel
    {
        public Carro carro { get; set; }
        public IList<Marca> marcas { get; set; }
        public IList<Modelo> modelos { get; set; }
    }
}