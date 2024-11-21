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
    public class User : IEntity
    {
         public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Ime {  get; set; }
        public string Prezime {  get; set; }

        [Browsable(false)]

        public string TableName => "[User]";
        [Browsable(false)]

        public string InsertValues => throw new NotImplementedException();
        [Browsable(false)]

        public string UpdateValues => "";
        [Browsable(false)]

        public string DeleteValues => "";
        [Browsable(false)]

        public string SelectValues => $"* from [User] where username='{Username}' and password='{Password}'";
        [Browsable(false)]

        public string SearchValues { get; set; }

        [Browsable(false)]

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> entiteti = new List<IEntity>();
            if (reader.Read())
            {
                User user = new User();
                user.Id = (int)reader["id"];
                user.Username = (string)reader["username"];
                user.Password = (string)reader["password"];
                user.Ime = (string)reader["ime"];
                user.Prezime = (string)reader["prezime"];
             
                reader.Close();

                entiteti.Add(user);
                return entiteti;
            }
            reader.Close();
            return null;
        }
    
    
    
    }
}
