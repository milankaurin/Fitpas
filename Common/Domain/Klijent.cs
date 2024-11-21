using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]

    public class Klijent : IEntity

    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
    
        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }

        [Browsable(false)]

        public string TableName => "[Korisnik]";
        [Browsable(false)]

        public string InsertValues => $"(ime, prezime, datumRodjenja) VALUES ('{Ime}', '{Prezime}', '{DatumRodjenja}')";
        [Browsable(false)]

        public string UpdateValues => $"ime = '{Ime}', prezime= '{Prezime}', datumRodjenja='{DatumRodjenja}' WHERE idKorisnika = {Id}";

        [Browsable(false)]

        public string DeleteValues => $"idKorisnika={Id}";
        [Browsable(false)]

        public string SelectValues =>"";
        [Browsable(false)]

        public string SearchValues { get; set; }
        [Browsable(false)]

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {

            List<IEntity> entiteti = new List<IEntity>();
            while (reader.Read())
            {
                Klijent klijent = new Klijent();
                klijent.Id = (int)reader["idKorisnika"];
                klijent.Ime = (string)reader["ime"];
                klijent.Prezime = (string)reader["prezime"];
                klijent.DatumRodjenja = (DateTime)reader["datumRodjenja"];
                entiteti.Add(klijent);
            }
            reader.Close();
            if (entiteti == null) { Console.WriteLine("problem"); }
            return entiteti;
        }
    }
}
