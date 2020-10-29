using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BTLWebASP.Models
{
    public class dataconnection
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;

        public dataconnection()
        {
            cn = new SqlConnection(str);
        }

        public DataTable layDeLieu(string query)
        {
            da = new SqlDataAdapter(query,cn);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void ghiDuLieu(string query)
        {
            cn.Open();
            cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();
        }
    }
}