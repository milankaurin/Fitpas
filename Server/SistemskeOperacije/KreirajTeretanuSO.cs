using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class KreirajTeretanuSO : SistemskaOperacijaBazicno
    {
        private Teretana teretana;
        public int result {  get; set; }

        public KreirajTeretanuSO(Teretana teretana)
        {
            this.teretana = teretana;
        }

        protected override void ExecuteConcreteOperation()
        {
            int a =broker.Kreiraj(teretana);
           
            result = a;
        }
    }
}
