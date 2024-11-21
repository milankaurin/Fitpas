using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class ObrisiClanarinuSO: SistemskaOperacijaBazicno {

        Clanarina clanarina;
    public ObrisiClanarinuSO(Clanarina clanarina)
    {
            this.clanarina = clanarina;
    }
    protected override void ExecuteConcreteOperation()
    {
        broker.Obrisi(clanarina);
    }
}

}

