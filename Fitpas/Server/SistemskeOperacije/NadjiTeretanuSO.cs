using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class NadjiTeretanuSO : SistemskaOperacijaBazicno
    {
        public List<Teretana> Result { get; set; }
        string pretraga;

        public NadjiTeretanuSO(string pretraga)
        {
            this.pretraga = pretraga.ToLower(); // Pretvaranje unosa u mala slova
        }

        protected override void ExecuteConcreteOperation()
        {
            Teretana teretana = new Teretana();
            // Kreira SQL upit koji pretražuje teretane po imenu teretane
            // Dodajemo LOWER() funkciju za neosetljivost na veličinu slova
            teretana.SearchValues = $@"
        * FROM Teretana 
        WHERE LOWER(imeTeretane) LIKE '%{pretraga}%'";

            List<IEntity> entiteti = broker.Pretrazi(teretana);
            List<Teretana> teretane = new List<Teretana>();
            foreach (IEntity item in entiteti)
            {
                teretane.Add((Teretana)item);
            }
            Result = teretane;
        }
    }
}

