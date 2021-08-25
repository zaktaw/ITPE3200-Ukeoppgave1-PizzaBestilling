using ITPE3200_Ukeoppgave1_PizzaBestilling.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITPE3200_Ukeoppgave1_PizzaBestilling.Controllers
{
    [Route("[controller]/[action]")] // kalle en url med kontrolleren og en metode

    public class KundeBestillingController : ControllerBase
    {
        private readonly KundeBestillingDb _db;

        public KundeBestillingController(KundeBestillingDb db)
        {
            _db = db;
        }

        public bool Lagre(Kunde innKunde)
        {
            try
            {
                _db.Add(innKunde);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Kunde> HentAlle()
        {
            try
            {
                List<Kunde> kunder = _db.Kunder.ToList();
                return kunder;
            }
            catch
            {
                return null;
            }
        }
    }
}
