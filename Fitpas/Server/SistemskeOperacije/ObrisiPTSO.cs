using Common;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class ObrisiPTSO : SistemskaOperacijaBazicno
    {
        PaketTeretana pt;
        public ObrisiPTSO(PaketTeretana pt)
        {
            this.pt = pt;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Obrisi(pt);
        }
    }
}

