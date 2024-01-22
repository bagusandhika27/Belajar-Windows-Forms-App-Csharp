using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Belajar_Inventori
{
    class Koneksi
    {
        public SqlConnection GetConn() 
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Integrated Security = True; initial catalog = belajarcsharp; MultipleActiveResultSets = True";
            return Conn;
        }
    }
}
