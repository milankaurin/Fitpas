using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class Clanarina : IEntity
    { public int Id { get; set; }
        public Klijent Klijent { get; set; }
        public Kategorija Kategorija { get; set; }
        public Paket Paket { get; set; }
        public int idPaketa { get; set; }
        public int idKlijenta { get; set; }
        public int idKategorije { get; set; }

        public bool Aktivno
        {
            get
            {
                return DatumDo > DateTime.Now;
            }
        }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public int Cena { get; set; }

        


        [Browsable(false)]
        public string TableName => "[Clanarina]";
        [Browsable(false)]
        public string InsertValues => $"(datumOd, datumDo, idKorisnika,idKategorije,idPaketa, cena) VALUES ('{DatumOd}', '{DatumDo}', '{Klijent.Id}','{Kategorija.Id}','{Paket.Id}','{Cena}')";
        [Browsable(false)]
        public string UpdateValues => throw new NotImplementedException();
        [Browsable(false)]
        public string DeleteValues => $"idClanarine={Id}";
        [Browsable(false)]
        public string SelectValues => throw new NotImplementedException();
        [Browsable(false)]
        public string SearchValues { get; set; }



        [Browsable(false)]


        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> entiteti = new List<IEntity>();
            while (reader.Read())
            {
                Clanarina c = new Clanarina();
                c.Cena = reader.GetInt32(reader.GetOrdinal("cena"));
                c.Id = reader.GetInt32(reader.GetOrdinal("idClanarine"));
                c.idKategorije = reader.GetInt32(reader.GetOrdinal("idKategorije"));
                c.Kategorija = new Kategorija
                {
                    Id = reader.GetInt32(reader.GetOrdinal("idKategorije")),
                    Naziv = reader.GetString(reader.GetOrdinal("imeKategorije")),
                    Popust = reader.GetInt32(reader.GetOrdinal("kolicinaPopusta"))
                };

                c.idPaketa = reader.GetInt32(reader.GetOrdinal("idPaketa"));
                c.Paket = new Paket
                {
                    Id = reader.GetInt32(reader.GetOrdinal("idPaketa")),
                    ImePaketa = reader.GetString(reader.GetOrdinal("imePaketa")),
                    Cena = reader.GetInt32(reader.GetOrdinal("PaketCena")) // Pretpostavljam da je cena decimal
                };

                c.idKlijenta = reader.GetInt32(reader.GetOrdinal("idKorisnika"));
                c.Klijent = new Klijent
                {
                    Id = reader.GetInt32(reader.GetOrdinal("idKorisnika")),
                    Ime = reader.GetString(reader.GetOrdinal("ime")),
                    Prezime = reader.GetString(reader.GetOrdinal("prezime")),
                    DatumRodjenja = reader.GetDateTime(reader.GetOrdinal("datumRodjenja"))

                };

                c.DatumDo = reader.GetDateTime(reader.GetOrdinal("datumDo"));
                c.DatumOd = reader.GetDateTime(reader.GetOrdinal("datumOd"));
                entiteti.Add(c);


            }
            reader.Close();
            if (entiteti == null) { Console.WriteLine("problem"); }
            return entiteti;
        }
    }



}