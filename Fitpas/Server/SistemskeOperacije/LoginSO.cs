using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
  
        public class LoginSO : SistemskaOperacijaBazicno {
            private readonly User user;
            public User Result { get; set; }

            public LoginSO(User user)
            {
                this.user = user;
            }

            protected override void ExecuteConcreteOperation()
            {

            List<IEntity> entiteti = broker.UcitajSveSaUslovom(user);

            if (entiteti != null)
            {
                Result = (User)entiteti[0];
            }
            else
            {
                Result = null;
            }

            }
    }
 }
    

