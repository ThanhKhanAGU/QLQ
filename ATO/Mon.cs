using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ATO
{
    public class Mon
    {
        public static List<DTO.Mon> get()
        {
            List<DTO.Mon> mon = new List<DTO.Mon>();
            SqlDataAdapter da = new SqlDataAdapter("select * from mon", Connect.connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for(int i=0;i<dt.Rows.Count;i++)
            {
                mon.Add(new DTO.Mon
                {
                    id = Int32.Parse(dt.Rows[i][0].ToString()),
                    tenmon = dt.Rows[i][1].ToString(),
                    tenloai = dt.Rows[i][2].ToString(),
                    gia = Int32.Parse(dt.Rows[i][0].ToString())
                }) ;
                
                
            }    
            return mon;
        }
        public static bool Add(DTO.Mon m)
        {
            try
            {
                if (Connect.connection.State == ConnectionState.Closed)
                    Connect.connection.Open();
                else Connect.connection.Open();
                SqlCommand dc = new SqlCommand(@"insert Mon(tenmon, tenloai, gia) values(N'" + m.tenmon + "', N'" + m.tenloai + "'," + m.gia + ")", Connect.connection);
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
                SqlCommand dc = new SqlCommand(@"delete Mon where id = "+id, Connect.connection);
                dc.ExecuteNonQuery();
                Connect.connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool Update(DTO.Mon m )
        {
            
                if (Connect.connection.State == ConnectionState.Closed)
                    Connect.connection.Open();
                else Connect.connection.Open();
                SqlCommand dc = new SqlCommand(@"update Mon set tenmon = N'"+m.tenmon+"', tenloai = N'"+m.tenloai+"',gia = "+m.gia+" where id = "+m.id, Connect.connection);
                dc.ExecuteNonQuery();
                Connect.connection.Close();
                return true;
            
        }
    }
}
