using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AluguerCarros.Models.AlugarCarros
{
    public class Avaliacao_Carro : Avaliacao
    {
        public int Estado_Veiculo { get; set; }
        public int Limpeza_Veiculo { get; set; }
        public int CarroID { get; set; }
    }
}