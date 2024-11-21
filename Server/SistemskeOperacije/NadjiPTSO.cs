using Common.Domain;
using Common;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class NadjiPTSO : SistemskaOperacijaBazicno
    {
        public List<PaketTeretana> Result { get; set; }
        Paket paket;
        Teretana teretana;
        int a = 0;
        public NadjiPTSO(Paket paket)
        {
            this.paket = paket;
            
        }
        public NadjiPTSO(Teretana teretana)
        {
            this.teretana = teretana;
            a = 1;
        }

        protected override void ExecuteConcreteOperation()
        {
            PaketTeretana pt = new PaketTeretana();


            if (a == 0)
            {
                pt.SearchValues = $@"
                *
                FROM [Paket-Teretana] pt
                JOIN Teretana t ON pt.idTeretane = t.idTeretane
                JOIN Paket p ON pt.idPaketa = p.idPaketa
                WHERE pt.idPaketa = {paket.Id}";
            }
            if (a == 1)
            {
                pt.SearchValues = $@"
               *
                FROM [Paket-Teretana] pt
                JOIN Teretana t ON pt.idTeretane = t.idTeretane
                JOIN Paket p ON pt.idPaketa = p.idPaketa
                WHERE pt.idTeretane = {teretana.Id}";
            }

            // Pozivanje metode za pretragu
            List<IEntity> entiteti = broker.Pretrazi(pt);

            List<PaketTeretana> paketiteretane = new List<PaketTeretana>();
            foreach (IEntity item in entiteti)
            {
                paketiteretane.Add((PaketTeretana)item);
            }
            Result = paketiteretane;
        }
    }
}
