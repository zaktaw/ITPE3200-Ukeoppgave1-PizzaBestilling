using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITPE3200_Ukeoppgave1_PizzaBestilling.Models
{
    public class KundeBestillingDb :DbContext
    {
        public KundeBestillingDb(DbContextOptions<KundeBestillingDb> options) : base(options)
        {
            Database.EnsureCreated(); // opprette databasen når vi starter applikasjonen
        }

        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<Bestilling> Bestillinger{ get; set; }
    }
}
