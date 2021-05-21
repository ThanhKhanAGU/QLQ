using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ATO
{
    public class Connect
    {
        public static SqlConnection connection = new SqlConnection(@"Data Source="+(System.IO.File.ReadAllText(@"conectionstring.txt") +@"; Initial Catalog=Duyquangcoffee;Integrated Security=True"));
        
        static void Main(string[] args)
        {

        }
        public static DataTable get(string query)
        {      
            SqlDataAdapter da = new SqlDataAdapter(query, Connect.connection);
            DataTable dt = new DataTable();
            da.Fill(dt);             
            return dt;          
        }
        public static bool post(string query)
        {
            try
            {
                if (Connect.connection.State == ConnectionState.Closed)
                    Connect.connection.Open();
                else Connect.connection.Open();
                SqlCommand dc = new SqlCommand(query, Connect.connection);
                dc.ExecuteNonQuery();
                Connect.connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
