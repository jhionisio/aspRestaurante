using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante.Models
{
    public class Restaurante
    {
        public int RestauranteId { get; set; }
        public string NomeRestaurante { get; set; }

        public virtual IEnumerable<Cardapio> Cardapio { get; set; }
        public IEnumerable<Restaurante> Lista()
        {
            DBRestaurante banco = new DBRestaurante();
            Restaurante restaurante = new Restaurante();

            IEnumerable<Restaurante> listaRestaurante = banco.Restaurante.ToList();
            return banco.Restaurante.ToList();
        }
    }

}