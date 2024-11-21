using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class NadjiKategorijuSO : SistemskaOperacijaBazicno
    {
        public List<Kategorija> Result { get; set; }
        string pretraga;

        public NadjiKategorijuSO(string pretraga)
        {
            this.pretraga = pretraga.ToLower(); // Pretvaranje unosa u mala slova
        }

        protected override void ExecuteConcreteOperation()
        {
            Kategorija kategorija = new Kategorija();
            // Kreira SQL upit koji pretražuje kategorije po imenu kategorije ili po količini popusta
            // Dodajemo LOWER() funkciju za neosetljivost na veličinu slova
            kategorija.SearchValues = $@"
        SELECT * FROM Kategorija 
        WHERE LOWER(imeKategorije) LIKE '%{pretraga}%' 
        OR CAST(kolicinaPopusta AS VARCHAR) LIKE '%{pretraga}%'";  // Pretvaranje količine popusta u VARCHAR za pretragu

            List<IEntity> entiteti = broker.Pretrazi(kategorija);
            List<Kategorija> kategorije = new List<Kategorija>();
            foreach (IEntity item in entiteti)
            {
                kategorije.Add((Kategorija)item);
            }
            Result = kategorije;
        }
    }

}
