using Common.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBroker
{
    public class Broker
    {
        private DBConnection connection;
        public Broker()
        {
            connection = new DBConnection();
        }

        public void CloseConnection()
        {
            connection.CloseConnection();
        }
        public void OpenConnection()
        {
            connection.OpenConnection();
        }
        public void Rollback()
        {
            connection.Rollback();
        }
        public void Commit()
        {
            connection.Commit();
        }
        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }
        public int Kreiraj(IEntity entity) //insert
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"insert into {entity.TableName} {entity.InsertValues}";
            object a = command.ExecuteScalar();
            
            if (a != null)
            {
                return (int) a;
            }
            else return 0;

        }
        public void Izmeni(IEntity entity)  //update
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE {entity.TableName} SET {entity.UpdateValues}";
            command.ExecuteNonQuery();

        }
        public void Obrisi(IEntity entity) //delete
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM {entity.TableName} WHERE {entity.DeleteValues}";
            command.ExecuteNonQuery();
        }
        public List<IEntity> Pretrazi(IEntity entity)  //select
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT {entity.SearchValues}";
            SqlDataReader reader = command.ExecuteReader();
            List<IEntity> clanovi = entity.GetReaderList(reader);
            return clanovi;
        }
        public List<IEntity> GetAll(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from {entity.TableName}";
            SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);

            return list;
        }
        public List<IEntity> UcitajSveSaUslovom(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select {entity.SelectValues}";
            SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);

            return list;
        }
    
    
    
    
    
    }


}

