using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class KreirajPaketSO : SistemskaOperacijaBazicno
    {
        private Paket paket;
        public int result {  get; set; }

        public KreirajPaketSO(Paket paket)
        {
            this.paket = paket;
        }

        protected override void ExecuteConcreteOperation()
        {
            int a = broker.Kreiraj(paket);
            result = a;
        }
    }
}
