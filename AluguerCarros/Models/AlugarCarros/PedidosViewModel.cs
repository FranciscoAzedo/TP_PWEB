using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AluguerCarros.Models.AlugarCarros
{
    public class PedidosViewModel
    {
        public IEnumerable<Pedido_Aluguer> pedidos_pendentes { get; set; }
        public IEnumerable<Pedido_Aluguer> pedidos_ativos { get; set; }
        public IEnumerable<Pedido_Aluguer> pedidos_resolvidos { get; set; }
    }
}