using Common;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class KreirajClanarinuSO : SistemskaOperacijaBazicno
    {
        Clanarina clanarina;
        public KreirajClanarinuSO(Clanarina clanarina)
        {
            this.clanarina = clanarina;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Kreiraj(clanarina);
        }
    }
}
