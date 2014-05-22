namespace ArtisanDB.Migrations
{
    using ArtisanDB.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ArtisanDB.Models.ArtisanDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ArtisanDB.Models.ArtisanDBContext context)
        {
            context.Companies.AddOrUpdate(i => i.name,
                new Company
                {
                    name = "Google",
                    incorpDate = DateTime.Parse("1989-1-11"),
                    stockname = "GOOG",
                    price = 505.50M
                },

                 new Company
                 {
                     name = "Foliotek",
                     incorpDate = DateTime.Parse("1989-1-11"),
                     stockname = "FOLIO",
                     price = 320.1M
                 }

                
           );

        }
    }
}
