using Common;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class AzurirajTeretanuSO : SistemskaOperacijaBazicno
    {
        private Teretana teretana;

        public AzurirajTeretanuSO(Teretana teretana)
        {
            this.teretana = teretana;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Izmeni(teretana);
        }
    }
}
