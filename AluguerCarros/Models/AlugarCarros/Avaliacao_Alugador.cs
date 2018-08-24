using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AluguerCarros.Models.AlugarCarros
{
    public class Avaliacao_Alugador : Avaliacao
    {
        public int Tempo_Resposta { get; set; }
        public int Simpatia { get; set; }
        public string Dono { get; set; }
    }
}