using Common;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class UcitajListuKlijenataSO : SistemskaOperacijaBazicno
    {
        public List<Klijent> Result { get; set; }



        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> entities = broker.GetAll(new Klijent());
            List<Klijent> klijenti = new List<Klijent>();
            foreach (Klijent entity in entities)
            {
               klijenti.Add(entity);
            }

            Result = klijenti;
        }
    }
}
