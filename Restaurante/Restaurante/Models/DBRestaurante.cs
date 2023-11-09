using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Restaurante.Models
{
    public class DBRestaurante : DbContext
    {
        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<Cardapio> Cardapio { get; set; }
    }
}