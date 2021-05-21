using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ATO
{
    public class Ban
    {
        public static DataTable get()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from ban", Connect.connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static bool Add(DTO.Ban b)
        {
            try
            {
                if (Connect.connection.State == ConnectionState.Closed)
                    Connect.connection.Open();
                else Connect.connection.Open();
                SqlCommand dc = new SqlCommand(@"insert ban( tenban,tang)
                                values (N'"+b.tenban+"',N'"+b.tentang+"')", Connect.connection);
                dc.ExecuteNonQuery();
                Connect.connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool Delete(int id)
        {
            try
            {
                if (Connect.connection.State == ConnectionState.Closed)
                    Connect.connection.Open();
                else Connect.connection.Open();
                SqlCommand dc = new SqlCommand(@"delete Mon where id = " + id, Connect.connection);
                dc.ExecuteNonQuery();
                Connect.connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool Update(DTO.Ban b)
        {

            if (Connect.connection.State == ConnectionState.Closed)
                Connect.connection.Open();
            else Connect.connection.Open();
            SqlCommand dc = new SqlCommand(@"update ban set tenban = N'"+b.tenban+"',tang = N'"+b.tentang+"' where id = " + b.id, Connect.connection);
            dc.ExecuteNonQuery();
            Connect.connection.Close();
            return true;

        }
    }
}
