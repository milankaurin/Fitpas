using Common.Domain;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class UcitajListuTeretanaSO : SistemskaOperacijaBazicno
    {
        public List<Teretana> Result { get; set; }



        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> entities = broker.GetAll(new Teretana());
            List<Teretana> klijenti = new List<Teretana>();
            foreach (Teretana entity in entities)
            {
                klijenti.Add(entity);
            }

            Result = klijenti;
        }
    }
}
