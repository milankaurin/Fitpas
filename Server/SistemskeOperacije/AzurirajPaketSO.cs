using Common;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class AzurirajPaketSO : SistemskaOperacijaBazicno
    {
        private Paket paket;

        public AzurirajPaketSO(Paket paket)
        {
            this.paket = paket;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Izmeni(paket);
        }
    }
}
