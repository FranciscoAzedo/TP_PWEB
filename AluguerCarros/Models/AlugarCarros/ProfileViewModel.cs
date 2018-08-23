using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AluguerCarros.Models.AlugarCarros
{
    public class ProfileViewModel
    {
        static public ApplicationUser utilizador;
        static public List<Avaliacao_Cliente> aval_Cli;
        static public List<Avaliacao_Alugador> aval_Dono;
        static public List<Carro> carros;
    }
}