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

    public class Teretana : IEntity
    {
        public int Id { get; set; }
        public string ImeTeretane {  get; set; }
        public List<Paket> Paketi { get; set; }


        [Browsable(false)]

        public string TableName => "[Teretana]";
        [Browsable(false)]

        public string InsertValues => $"(imeTeretane) OUTPUT Inserted.idTeretane VALUES ('{ImeTeretane}')";
        [Browsable(false)]

      

        public string UpdateValues => $"imeTeretane = '{ImeTeretane}' WHERE idTeretane = {Id}";
        [Browsable(false)]

        public string DeleteValues => $"idTeretane={Id}";
        [Browsable(false)]

        public string SelectValues => "";
        [Browsable(false)]

        public string SearchValues { get; set ; }
        [Browsable(false)]

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> entiteti = new List<IEntity>();
            while (reader.Read())
            {
                Teretana teretana = new Teretana();
                teretana.Id = (int)reader["idTeretane"];
                teretana.ImeTeretane = (string)reader["imeTeretane"];
                entiteti.Add(teretana);
            }
            reader.Close();
            return entiteti;

        }
    
    
    
    
    }
}
