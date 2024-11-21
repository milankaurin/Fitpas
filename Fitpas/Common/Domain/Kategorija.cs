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

    public class Kategorija : IEntity
    {
        public string Naziv { get; set; }
        public int Popust { get; set; }



        [Browsable(false)]

        public int Id { get; set; }

        [Browsable(false)]

        public string TableName => "[Kategorija]";
        [Browsable(false)]

        public string InsertValues => "";
        [Browsable(false)]

        public string UpdateValues => "";
        [Browsable(false)]

        public string DeleteValues => "";
        [Browsable(false)]

        public string SelectValues => "";
        [Browsable(false)]

        public string Prikaz { get
            {
                return $"{Naziv} ({Popust}% popust)";
            }
        }
        [Browsable(false)]

        public override string ToString()
        {
           
            
                return $"{Naziv} ({Popust}% popust)";
            
        }
        [Browsable(false)]

        public string SearchValues { get; set; }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> entiteti = new List<IEntity>();
            while (reader.Read())
            {
                Kategorija kategorija = new Kategorija();
                kategorija.Id = (int)reader["idKategorije"];
                kategorija.Naziv = (string)reader["imeKategorije"];
                kategorija.Popust = (int)reader["kolicinaPopusta"];
                entiteti.Add(kategorija);
            }

            return entiteti;
        }
    }
}
