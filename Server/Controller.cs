using Common;
using Common.CommunicationHelper;
using Common.Domain;
using DBBroker;
using Server.SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Server
{
    public class Controller
    {
        private Broker broker;

        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null) instance = new Controller();
                return instance;
            }
        }
        private Controller() { broker = new Broker(); }


        public User Login(User user)
        {
            LoginSO so = new LoginSO(user);
            so.ExecuteTemplate();
            return so.Result;

        }

       
        public void KreirajKlijenta(Klijent klijent)
        {
            KreirajKlijentaSO so = new KreirajKlijentaSO(klijent);
            so.ExecuteTemplate();
        }

        public void KreirajKategoriju(Kategorija kategorija)
        {
            KreirajKategorijuSO so = new KreirajKategorijuSO(kategorija);
            so.ExecuteTemplate();
        }

        public int KreirajPaket(Paket paket)
        {
            KreirajPaketSO so = new KreirajPaketSO(paket);
            so.ExecuteTemplate();
            return so.result;
        }

        public int KreirajTeretanu(Teretana teretana)
        {
            KreirajTeretanuSO so = new KreirajTeretanuSO(teretana);
            so.ExecuteTemplate();
            return so.result;
        }

        public void KreirajClanarinu(Clanarina clanarina)
        {
          KreirajClanarinuSO so = new KreirajClanarinuSO(clanarina);
           so.ExecuteTemplate();
        }

        public List<Paket> UcitajListuPaketa()
        {
            UcitajListuPaketaSO so = new UcitajListuPaketaSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Klijent> UcitajListuKlijenata()
        {
            UcitajListuKlijenataSO so = new UcitajListuKlijenataSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Klijent> NadjiKlijente(string tekst)
        {
            NadjiKlijentaSO so = new NadjiKlijentaSO(tekst);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Teretana> UcitajListuTeretana()
        {
            UcitajListuTeretanaSO so = new UcitajListuTeretanaSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Kategorija> UcitajListuKategorija()
        {
            UcitajListuKategorijaSO so = new UcitajListuKategorijaSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Clanarina> UcitajListuClanarina()
        {
            UcitajListuClanarinaSO so = new UcitajListuClanarinaSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public void ObrisiKlijenta(Klijent klijent)
        {
            ObrisiKlijentaSO obrisiKlijentaSO = new ObrisiKlijentaSO(klijent);
            obrisiKlijentaSO.ExecuteTemplate();
        }
        public void ObrisiPaket(Paket paket)
        {
            ObrisiPaketSO obrisiPaketSO = new ObrisiPaketSO(paket);
            obrisiPaketSO.ExecuteTemplate();
            
        }
        public void ObrisiTeretanu(Teretana teretana)
        {
            ObrisiTeretanuSO obrisiTeretanuSO = new ObrisiTeretanuSO(teretana);
            obrisiTeretanuSO.ExecuteTemplate();
        }
        public void ObrisiKategoriju(Kategorija kategorija)
        {
            ObrisiKategorijuSO obrisiKategorijuSO = new ObrisiKategorijuSO(kategorija);
            obrisiKategorijuSO.ExecuteTemplate();
        }
        public void AzurirajKategoriju(Kategorija kategorija)
        {
            AzurirajKategorijuSO azurirajKategorijuSO = new AzurirajKategorijuSO(kategorija);
            azurirajKategorijuSO.ExecuteTemplate();
        }
        public void AzurirajKlijenta(Klijent klijent)
        {
            AzurirajKlijentaSO azurirajKlijentaSO = new AzurirajKlijentaSO(klijent);
            azurirajKlijentaSO.ExecuteTemplate();
        }
        public void AzurirajPaket(Paket paket)
        {
            AzurirajPaketSO azurirajPaketSO = new AzurirajPaketSO(paket);
            azurirajPaketSO.ExecuteTemplate();
        }
        public void AzurirajTeretanu(Teretana teretana)
        {
            AzurirajTeretanuSO azurirajTeretanuSO = new AzurirajTeretanuSO(teretana);
            azurirajTeretanuSO.ExecuteTemplate();
        }

        internal void KreirajPT(PaketTeretana paketTeretana)
        {
            KreirajPTSO so = new KreirajPTSO(paketTeretana);
            so.ExecuteTemplate();

        }

        public List<PaketTeretana> NadjiPTSO(object argument)
        {
            if (argument is Paket paket)
            {
                NadjiPTSO so = new NadjiPTSO(paket);
                so.ExecuteTemplate();
                return so.Result;
            }
            else if (argument is Teretana teretana)
            {
                NadjiPTSO so = new NadjiPTSO(teretana);
                so.ExecuteTemplate();
                return so.Result;
            }
            else
            {
                throw new ArgumentException("Argument must be of type Paket or Teretana.");
            }
        }
            internal List<Clanarina> NadjiClanarinu(String idKlijenta)
        {
            NadjiClanarinuSO so = new NadjiClanarinuSO(idKlijenta);
            so.ExecuteTemplate(); return so.Result;
        }

        internal void ObrisiPT(PaketTeretana argument)
        {
            ObrisiPTSO so = new ObrisiPTSO(argument);
            so.ExecuteTemplate();
        }

        internal void ObrisiClanarinu(Clanarina argument)
        {
            ObrisiClanarinuSO so = new ObrisiClanarinuSO(argument);
            so.ExecuteTemplate();
        }

        internal List<Teretana> PretraziTeretanu(string argument)
        {
            NadjiTeretanuSO so = new NadjiTeretanuSO(argument);
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
