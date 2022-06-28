using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siparis.WinUI
{
    public interface IDbcontext
    {
        public DataTable ExecuteQuery(string sql, CommandType commandType, params SqlParameter[] parametreler);
        public int ExecuteNonQuery(string sql, CommandType commandType, params SqlParameter[] parametreler);



    }
}
