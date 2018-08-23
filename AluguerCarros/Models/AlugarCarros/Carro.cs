using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AluguerCarros.Models.AlugarCarros
{
    public class Carro
    {
        [Key]
        public int CarroID { get; set; }   
        [Required]
        public string Matricula { get; set; }        
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Combustivel { get; set; }
        public int Lugares { get; set; }
        public string Portas { get; set; }
        // Fotos
        public int Preco_Diario { get; set; }
        public int Preco_Mensal { get; set; }
        public string Condicoes { get; set; }
        public string Zona { get; set; }
        public virtual IList<String> Locais_Entrega { get; set; }
        public bool Disponivel { get; set; }

        public string DonoID { get; set; }

        public virtual IList<Avaliacao_Carro> Avaliacao_Veiculo { get; set; }
    }
}