using Common.Domain;
using Common;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class NadjiKlijentaSO: SistemskaOperacijaBazicno
    {
        public List<Klijent> Result { get; set; }
        string pretraga;
        public NadjiKlijentaSO(string pretraga)
        {
            this.pretraga = pretraga;
        }

        protected override void ExecuteConcreteOperation()
        {
            Klijent klijent = new Klijent();

            // Pretpostavimo da je 'pretraga' već definisana negde u tvom kodu i da sadrži korisnički unos
            string pretragaMalaSlova = pretraga.ToLower(); // Konverzija unosa u mala slova

            
            klijent.SearchValues= $@"
            * FROM Korisnik 
            WHERE (LOWER(ime + ' ' + prezime) LIKE '%{pretragaMalaSlova}%' 
            OR LOWER(prezime + ' ' + ime) LIKE '%{pretragaMalaSlova}%') 
            OR LOWER(ime) LIKE '%{pretragaMalaSlova}%' 
            OR LOWER(prezime) LIKE '%{pretragaMalaSlova}%' 
            OR CAST(datumRodjenja AS VARCHAR) LIKE '%{pretragaMalaSlova}%'";

            // Pozivanje metode za pretragu
            List<IEntity> entiteti = broker.Pretrazi(klijent);

            List<Klijent> klijenti = new List<Klijent>();
            foreach (IEntity item in entiteti)
            {
                klijenti.Add((Klijent)item);
            }
            Result = klijenti;  
        }
    }
}
