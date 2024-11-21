using Common.Domain;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class UcitajListuClanarinaSO : SistemskaOperacijaBazicno
    {
        public List<Clanarina> Result { get; set; }



        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> entities = broker.GetAll(new Clanarina());
            List<Clanarina> klijenti = new List<Clanarina>();
            foreach (Clanarina entity in entities)
            {
                klijenti.Add(entity);
            }

            Result = klijenti;
        }
    }
}
