using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATO
{
    public class LoaiMon
    {
        public static List<string> get()
        {
            List<string> mon = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter("select * from loai", Connect.connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow r in dt.Rows)
                mon.Add(r[0].ToString());
            return mon;
        }
        public static bool Add(string s)
        {
            try {
                if (Connect.connection.State == ConnectionState.Closed)
                    Connect.connection.Open();
                else Connect.connection.Open();
                SqlCommand dc = new SqlCommand(@"insert loai(tenloai) values (N'" + s + "')",Connect.connection);
                dc.ExecuteNonQuery();
                Connect.connection.Close();
                return true;           
            } catch
            {
                return false;
            }   
        }
        public static bool Delete(string s)
        {
            try
            {
                if (Connect.connection.State == ConnectionState.Closed)
                    Connect.connection.Open();
                else Connect.connection.Open();
                SqlCommand dc = new SqlCommand(@"DELETE FROM loai WHERE tenloai = N'" + s + "'", Connect.connection);
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
