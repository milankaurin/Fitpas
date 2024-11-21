using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class UcitajListuPaketaSO : SistemskaOperacijaBazicno
    {
        public List<Paket> Result {  get; set; }

            

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> entities = broker.GetAll(new Paket());
            List<Paket> paketi = new List<Paket>();
            foreach(Paket entity in entities)
            {
                paketi.Add(entity);
            }

            Result = paketi;
        }
    }
}
