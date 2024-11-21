using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public interface IEntity
    {
        string TableName { get; }
        string InsertValues { get; }
        string UpdateValues { get; }
        string DeleteValues { get; }
        string SelectValues { get; }
        string SearchValues { get; set; }


        List<IEntity> GetReaderList(SqlDataReader reader);
    }
}


