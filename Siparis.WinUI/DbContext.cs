using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siparis.WinUI
{
    public class DbContext : IDbcontext
    {
        private SqlConnection _conn;
        private SqlCommand _cmd;
        private SqlDataReader _rdr;
        private DataTable _tbl;
        public DbContext(string str = null)
        {
            if(str==null)
            _conn = new SqlConnection(Parametreler.Nortwindconstr);
            else
                _conn = new SqlConnection(str);


            _cmd = new SqlCommand();
            _cmd.Connection = _conn;
        }

       

        public int ExecuteNonQuery(string sql, CommandType commandType, params SqlParameter[] parametreler)
        {
            switch (commandType)
            {
                case CommandType.Text:
                    _cmd.CommandType = CommandType.Text;
                    break;
                case CommandType.StoredProcedure:
                    {
                        _cmd.CommandType = CommandType.StoredProcedure;
                        if (parametreler != null)
                            _cmd.Parameters.AddRange(parametreler);
                    }
                    break;

                default:
                    break;
            }

            return _cmd.ExecuteNonQuery();
            
        }

        public DataTable ExecuteQuery(string sql, CommandType commandType, params SqlParameter[] parametreler)
        {
            switch (commandType)
            {
                case CommandType.Text:
                    _cmd.CommandType = CommandType.Text;
                    break;
                case CommandType.StoredProcedure:
                    {
                        _cmd.CommandText = sql;
                        _cmd.CommandType = CommandType.StoredProcedure;
                        if (parametreler != null)
                            _cmd.Parameters.AddRange(parametreler);
                    }
                    break;

                default:
                    break;
            }
            _conn.Open();
            _tbl = new DataTable();
            _tbl.Load(_cmd.ExecuteReader());
            _conn.Close();
            return _tbl;
        }

       
    }
}
