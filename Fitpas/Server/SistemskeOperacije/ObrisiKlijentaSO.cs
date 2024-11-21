using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class ObrisiKlijentaSO : SistemskaOperacijaBazicno
    {
        Klijent klijent;
        public ObrisiKlijentaSO(Klijent klijent)
        {
            this.klijent = klijent;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Obrisi(klijent);
        }
    }
}
