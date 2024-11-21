using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class Paket : IEntity
    {   public int Id {  get; set; }
        public string ImePaketa {  get; set; }
        public List<Teretana> Teretane { get; set; }
        public int Cena {  get; set; }

        public override string ToString()
        {
            return ImePaketa;
        }
        public string Prikaz
        {
            get
            {
                return $"{ImePaketa} (cena: {Cena})";
            }
        }

        [Browsable(false)]

        public string TableName => "[Paket]";
        [Browsable(false)]

        public string InsertValues => $"(imePaketa, cena) OUTPUT Inserted.idPaketa VALUES ('{ImePaketa}', '{Cena}')";
        [Browsable(false)]

        public string UpdateValues => $"imePaketa = '{ImePaketa}', cena='{Cena}' WHERE idPaketa = {Id}";


        public string DeleteValues => $"idPaketa={Id}";
        [Browsable(false)]

        public string SelectValues => "";
        [Browsable(false)]


        public string SearchValues { get; set; }
        [Browsable(false)]

      


        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> entiteti = new List<IEntity>();
            while (reader.Read())
            {
                Paket paket = new Paket();
                paket.Id = (int)reader["idPaketa"];
                paket.ImePaketa = (string)reader["imePaketa"];
                paket.Cena = (int)reader["cena"];
                entiteti.Add(paket);
            }
            reader.Close();
            return entiteti;
        }
    }
}
