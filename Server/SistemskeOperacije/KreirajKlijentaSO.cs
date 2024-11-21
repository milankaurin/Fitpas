using Common;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class KreirajKlijentaSO : SistemskaOperacijaBazicno
    {
        Klijent klijent;
        public KreirajKlijentaSO(Klijent klijent)
        {
            this.klijent = klijent;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Kreiraj(klijent);
        }
    }
}
