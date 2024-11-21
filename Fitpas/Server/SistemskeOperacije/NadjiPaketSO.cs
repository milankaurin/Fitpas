using Common.Domain;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class NadjiPaketSO : SistemskaOperacijaBazicno
    {
        public List<Paket> Result { get; set; }
        string pretraga;

        public NadjiPaketSO(string pretraga)
        {
            this.pretraga = pretraga.ToLower(); // Pretvaranje unosa u mala slova
        }

        protected override void ExecuteConcreteOperation()
        {
            Paket paket = new Paket();
            // Kreira SQL upit koji pretražuje pakete po imenu paketa ili po ceni
            // Dodajemo LOWER() funkciju za neosetljivost na veličinu slova
            paket.SearchValues = $@"
            SELECT * FROM Paket 
            WHERE LOWER(imePaketa) LIKE '%{pretraga}%' 
            OR CAST(cena AS VARCHAR) LIKE '%{pretraga}%'";  // Pretpostavka je pretraga po ceni već numerička

            List<IEntity> entiteti = broker.Pretrazi(paket);
            List<Paket> paketi = new List<Paket>();
            foreach (IEntity item in entiteti)
            {
                paketi.Add((Paket)item);
            }
            Result = paketi;
        }
    }
    
    }

