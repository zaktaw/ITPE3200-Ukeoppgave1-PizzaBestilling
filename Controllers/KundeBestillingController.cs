using ITPE3200_Ukeoppgave1_PizzaBestilling.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public bool Lagre(KundeBestilling innBestilling)
        {
            try
            {
                Kunde kunde = _db.Kunder.FirstOrDefault(k => k.navn == innBestilling.navn);

                // kunde finnes ikke i databasen: legg til kunde og bestilling
                if (kunde == null)
                {
                    Kunde nyKunde = new Kunde();
                    nyKunde.navn = innBestilling.navn;
                    nyKunde.adresse = innBestilling.adresse;
                    nyKunde.telefonnummer = innBestilling.telefonnummer;

                    _db.Kunder.Add(nyKunde);
                    _db.SaveChanges();

                    Bestilling nyBestilling = new Bestilling();
                    nyBestilling.kunde = nyKunde;
                    nyBestilling.type= innBestilling.type;
                    nyBestilling.tykkelse = innBestilling.tykkelse;
                    nyBestilling.antall = innBestilling.antall;

                    _db.Bestillinger.Add(nyBestilling);
                    _db.SaveChanges();
                   
                    return true;
                }
                // kunde finnes i databasen: legg kun til bestilling
                else
                {
                    Bestilling nyBestilling = new Bestilling();
                    nyBestilling.kunde = kunde;
                    nyBestilling.type = innBestilling.type;
                    nyBestilling.tykkelse = innBestilling.tykkelse;
                    nyBestilling.antall = innBestilling.antall;

                    _db.Bestillinger.Add(nyBestilling);
                    _db.SaveChanges();

                    return true;
                }
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
