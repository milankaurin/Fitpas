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
    public class PaketTeretana : IEntity
    {   public int IdPaketa {  get; set; }
        public int IdTeretane {  get; set; }
        public Teretana Teretana { get; set; }
        public Paket Paket { get; set; }


        [Browsable(false)]

        public string TableName => "[Paket-Teretana]";
        [Browsable(false)]

        public string InsertValues => $"(idPaketa, idTeretane) VALUES ({Paket.Id},{Teretana.Id})";
        [Browsable(false)]

        public string UpdateValues => "";
        [Browsable(false)]

        public string DeleteValues => $"idPaketa = {IdPaketa}";
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
                PaketTeretana pt = new PaketTeretana();
                pt.IdPaketa = (int)reader["idPaketa"];
                pt.IdTeretane = (int)reader["idTeretane"];
                pt.Teretana = new Teretana {
                    Id = (int)reader["idTeretane"],
                    ImeTeretane = (string)reader["imeTeretane"]
                };
                pt.Paket = new Paket
                {
                    Id = (int)reader["idPaketa"],
                    ImePaketa = (string)reader["imePaketa"]


                };
                entiteti.Add(pt);
            }
                
            
            reader.Close();
            if (entiteti == null) { Console.WriteLine("problem"); }
            return entiteti;
        }
    }
}
