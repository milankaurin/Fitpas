using Common;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class AzurirajKategorijuSO : SistemskaOperacijaBazicno
    {
        private Kategorija kategorija;

        public AzurirajKategorijuSO(Kategorija kategorija)
        {
            this.kategorija = kategorija;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Izmeni(kategorija);
        }
    }
}
