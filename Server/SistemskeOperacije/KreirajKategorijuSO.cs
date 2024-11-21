using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class KreirajKategorijuSO : SistemskaOperacijaBazicno
    {
        private Kategorija kategorija;

        public KreirajKategorijuSO(Kategorija kategorija)
        {
            this.kategorija = kategorija;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Kreiraj(kategorija);

        }
    }
}
