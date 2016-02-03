using System.Collections.Generic;
using Mvc5.App.Data;

namespace Mvc5.App.Migrations.BeersDbContext
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Mvc5.App.Data.BeersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\BeersDbContext";
        }

        protected override void Seed(Mvc5.App.Data.BeersContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var beers = new List<Beer>()
            {
                new Beer() {Name = "Classic"},
                new Beer() {Name = "Hof"}
            };

            beers.ForEach(beer => context.Beers.AddOrUpdate(beer));
            context.SaveChanges();
        }
    }
}
