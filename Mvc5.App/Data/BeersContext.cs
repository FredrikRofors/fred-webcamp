using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc5.App.Data
{
    public class BeersContext : DbContext
    {
        public BeersContext() : base("DefaultConnection")
        {
        }

        public DbSet<Beer> Beers { get; set; }
    }

    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}