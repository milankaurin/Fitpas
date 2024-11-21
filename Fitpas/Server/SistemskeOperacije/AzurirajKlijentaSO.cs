﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class AzurirajKlijentaSO : SistemskaOperacijaBazicno
    {
        private Klijent klijent;

        public AzurirajKlijentaSO(Klijent klijent)
        {
            this.klijent = klijent;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Izmeni(klijent);
        }
    }
}
