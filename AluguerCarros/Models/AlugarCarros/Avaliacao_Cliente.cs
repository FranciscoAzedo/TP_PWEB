using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AluguerCarros.Models.AlugarCarros
{
    public class Avaliacao_Cliente : Avaliacao
    {
        public int Comportamento { get; set; }
        public int Estado_Veiculo { get; set; }
        public string Cliente { get; set; }
    }
}