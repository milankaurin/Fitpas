using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class ObrisiKategorijuSO : SistemskaOperacijaBazicno
    {
        private Kategorija kategorija;

        public ObrisiKategorijuSO(Kategorija kategorija)
        {
            this.kategorija = kategorija;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Obrisi(kategorija);
        }
    }

}
