namespace Restaurante.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Restaurante.Models.DBRestaurante>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Restaurante.Models.DBRestaurante";
        }

        protected override void Seed(Restaurante.Models.DBRestaurante context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
           // context.Restaurante.AddOrUpdate(
               //   p => p.NomeRestaurante,
               //   new Restaurante.Models.Restaurante { NomeRestaurante = "King Shake" },
               //   new Restaurante.Models.Restaurante { NomeRestaurante = "X Burguer" },
               //   new Restaurante.Models.Restaurante { NomeRestaurante = "Kasato Maroto" },
               //   new Restaurante.Models.Restaurante { NomeRestaurante = "Kabana's" },
               //   new Restaurante.Models.Restaurante { NomeRestaurante = "Cozinha da Terra" },
               //   new Restaurante.Models.Restaurante { NomeRestaurante = "Cozinha Mineira" },
               //   new Restaurante.Models.Restaurante { NomeRestaurante = "Restaurante Italiano" }
               //   );
           // context.Cardapio.AddOrUpdate(
             //   p => p.nomePrato,
               // new Restaurante.Models.Cardapio { nomePrato = "Açai", valorPrato = 7.00F}
                //)

               
            //
        }
    }
}
