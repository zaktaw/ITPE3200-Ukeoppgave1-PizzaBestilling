using ITPE3200_Ukeoppgave1_PizzaBestilling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> Lagre(KundeBestilling innBestilling)
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

                    Bestilling nyBestilling = new Bestilling();
                    nyBestilling.type= innBestilling.type;
                    nyBestilling.tykkelse = innBestilling.tykkelse;
                    nyBestilling.antall = innBestilling.antall;

                    nyKunde.bestillinger = new List<Bestilling>();
                    nyKunde.bestillinger.Add(nyBestilling);

                    _db.Kunder.Add(nyKunde);
                    _db.Bestillinger.Add(nyBestilling);

                    await _db.SaveChangesAsync();
                   
                    return true;
                }
                // kunde finnes i databasen: legg kun til bestilling
                else
                {
                    Bestilling nyBestilling = new Bestilling();
                    nyBestilling.type = innBestilling.type;
                    nyBestilling.tykkelse = innBestilling.tykkelse;
                    nyBestilling.antall = innBestilling.antall;

                    kunde.bestillinger.Add(nyBestilling);

                    _db.Bestillinger.Add(nyBestilling);
                    await _db.SaveChangesAsync();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<KundeBestilling>> HentAlle()
        {
            try
            {
                List<KundeBestilling> kbs = new List<KundeBestilling>();
                List<Kunde> kunder = await _db.Kunder.ToListAsync();

                foreach (var kunde in kunder)
                {
                    foreach (var bestilling in kunde.bestillinger)
                    {
                        KundeBestilling kundeBestilling = new KundeBestilling();

                        kundeBestilling.id = bestilling.id;
                        kundeBestilling.type = bestilling.type;
                        kundeBestilling.tykkelse = bestilling.tykkelse;
                        kundeBestilling.antall = bestilling.antall;
                        kundeBestilling.navn = kunde.navn;
                        kundeBestilling.telefonnummer = kunde.telefonnummer;
                        kundeBestilling.adresse = kunde.adresse;

                        kbs.Add(kundeBestilling);
                    }
                }
             

                return kbs;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> SlettEn(int id)
        {
            try
            {
                Bestilling funnetBestilling = await _db.Bestillinger.FindAsync(id);
                _db.Bestillinger.Remove(funnetBestilling);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
