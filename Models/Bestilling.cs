﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITPE3200_Ukeoppgave1_PizzaBestilling.Models
{
    public class Bestilling
    {
        public int id { get; set; }
        public Kunde kunde { get; set; }
        public string type { get; set; }
        public string tykkelse { get; set; }
        public string antall { get; set; }
    }
}
