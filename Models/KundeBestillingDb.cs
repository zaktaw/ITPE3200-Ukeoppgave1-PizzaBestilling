using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITPE3200_Ukeoppgave1_PizzaBestilling.Models
{

    public class Kunde
    {
        public int id { get; set; }
        public string navn { get; set; }
        public string telefonnummer { get; set; }
        public string adresse { get; set; }
        public virtual List<Bestilling> bestillinger { get; set; }
    }

    public class Bestilling
    {
        public int id { get; set; }
        public string type { get; set; }
        public string tykkelse { get; set; }
        public string antall { get; set; }
    }

    public class KundeBestillingDb :DbContext
    {
        public KundeBestillingDb(DbContextOptions<KundeBestillingDb> options) : base(options)
        {
            Database.EnsureCreated(); // opprette databasen når vi starter applikasjonen
        }

        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<Bestilling> Bestillinger{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
