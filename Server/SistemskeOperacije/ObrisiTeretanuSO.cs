﻿using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class ObrisiTeretanuSO : SistemskaOperacijaBazicno
    {
        Teretana teretana;
        public ObrisiTeretanuSO(Teretana teretana)
        {
            this.teretana = teretana;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Obrisi(teretana);
        }

    }
}
