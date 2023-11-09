using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Restaurante.Models
{
    public class Cardapio
    {
        public int CardapioId { get; set; }

        public Restaurante Restaurante { get; set; }

        [Required(ErrorMessage = "Nome do prato deve ser preenchido")]
        public string nomePrato { get; set; }

        [Required(ErrorMessage = "Valor do prato deve ser preenchido")]
        public float valorPrato { get; set; }

        public IEnumerable<Cardapio> Lista()
        {
            DBRestaurante banco = new DBRestaurante();
            Cardapio cardapio = new Cardapio();

            return banco.Cardapio.Include(x=>x.Restaurante).ToList();
        }
    }
}