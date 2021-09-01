using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITPE3200_Ukeoppgave1_PizzaBestilling.Models
{
    public class KundeBestilling
    {
        public int id { get; set; }
        public string type { get; set; }
        public string tykkelse { get; set; }
        public string antall { get; set; }
        public string navn { get; set; }
        public string telefonnummer { get; set; }
        public string adresse { get; set; }
    }
}
