using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class KreirajPTSO : SistemskaOperacijaBazicno
    {

        private PaketTeretana paketTeretana;

        public KreirajPTSO(PaketTeretana paketTeretana)
        {
         this.paketTeretana=paketTeretana;
        }

        
        protected override void ExecuteConcreteOperation()
        {
            broker.Kreiraj(paketTeretana);
        }
    }
}
