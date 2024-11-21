using Common;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class ObrisiPaketSO : SistemskaOperacijaBazicno
    {
        Paket paket;
        public ObrisiPaketSO(Paket paket)
        {
            this.paket = paket;
        }
        protected override void ExecuteConcreteOperation()
        {
            try
            {
                broker.Obrisi(paket);  // Pretpostavka da ova metoda baca izuzetak ako brisanje nije moguće
            }
            catch (Exception ex)
            {
                throw new Exception("Paket se ne može obrisati: " + ex.Message, ex);
            }
        }
    }
}
