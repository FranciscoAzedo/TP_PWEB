using AluguerCarros.Models.AlugarCarros;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AluguerCarros.Models.DataContext
{
    public class AluguerCarrosContext : DbContext
    {
        public AluguerCarrosContext() : base("DefaultConnection")
        { }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Pedido_Aluguer> Pedidos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
    }
}