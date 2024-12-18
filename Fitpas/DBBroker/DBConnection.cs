﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBroker
{
    public class DBConnection
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public DBConnection()
        {
            //connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Fitpas"].ConnectionString);
            connection=new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Fitpas;
                    Integrated Security=True; MultipleActiveResultSets=True");
        }
    

        public void OpenConnection()
        {
            connection?.Open();
        }

        public void CloseConnection()
        {
            connection?.Close();
        }

        public void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
        }
        public void Commit()
        {
            transaction?.Commit();
        }
        public void Rollback()
        {
            transaction.Rollback();
        }
        public SqlCommand CreateCommand()
        {
            return new SqlCommand("", connection, transaction);
        }
    }
}
