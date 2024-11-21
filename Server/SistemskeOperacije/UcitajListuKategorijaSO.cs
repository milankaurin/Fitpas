using Common.Domain;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class UcitajListuKategorijaSO : SistemskaOperacijaBazicno
    {
        public List<Kategorija> Result { get; set; }



        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> entities = broker.GetAll(new Kategorija());
            List<Kategorija> klijenti = new List<Kategorija>();
            foreach (Kategorija entity in entities)
            {
                klijenti.Add(entity);
            }

            Result = klijenti;
        }
    }
}
