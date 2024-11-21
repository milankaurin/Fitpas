using Common;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class NadjiClanarinuSO : SistemskaOperacijaBazicno
    {
        public List<Clanarina> Result { get; set; }
        string pretraga;
        public NadjiClanarinuSO(string pretraga)
        {
            this.pretraga = pretraga;
        }
        protected override void ExecuteConcreteOperation()
        { 
            Clanarina clanarina = new Clanarina();
            clanarina.SearchValues = $@"
            Clanarina.idClanarine,
        Korisnik.ime,
        Korisnik.prezime, 
        Korisnik.idKorisnika, Korisnik.datumRodjenja,
        Clanarina.cena,
        Paket.imePaketa, 
        Paket.idPaketa, 
        Paket.cena AS PaketCena,
        Kategorija.imeKategorije, 
        Kategorija.idKategorije, 
        Kategorija.kolicinaPopusta,
        Clanarina.datumOd, 
        Clanarina.datumDo
    FROM
        Clanarina
    LEFT JOIN
        Korisnik ON Clanarina.idKorisnika = Korisnik.idKorisnika
    LEFT JOIN
        Paket ON Clanarina.idPaketa = Paket.idPaketa
    LEFT JOIN
        Kategorija ON Clanarina.idKategorije = Kategorija.idKategorije
            WHERE Clanarina.idKorisnika = '{pretraga}'";

            List<IEntity> entiteti = broker.Pretrazi(clanarina);

            List<Clanarina> clanarine = new List<Clanarina>();
            foreach (IEntity item in entiteti)
            {
                clanarine.Add((Clanarina)item);
            }
            Result = clanarine;

        }
    }
}
