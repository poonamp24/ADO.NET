using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management_Syatem
{
    public class DAL
    {
        public ConnectionState state = ConnectionState.Closed;
        public bool isProcall = false;
        List<SqlParameter> paralist = new List<SqlParameter>();
        private SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-EN04RVE\\SQLEXPRESS01;Initial Catalog=Cafe_Project;Integrated Security=True";
            return con;

        }

        public void clearparameter()
        {
            paralist.Clear();
        }
        public void AddParameters(string paraname, string value)
        {
            paralist.Add(new SqlParameter(paraname, value));
        }

        public SqlCommand GetCommand(String Query)
        {
            SqlCommand cmd = new SqlCommand();

            if (isProcall)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(paralist.ToArray());
            }
            else
            {
                cmd.CommandType = CommandType.Text;

            }
            cmd.CommandText = Query;
            cmd.Connection = GetConnection();

            return cmd;

        }

        public object GetID(string Query)
        {
            SqlCommand cmd = GetCommand(Query);
            cmd.Connection.Open();
            object retval = cmd.ExecuteScalar();
            cmd.Connection.Close();

            return retval;
        }
       
        public int ExecuteQuery(string Query)
        {
            SqlCommand cmd = GetCommand(Query);
            cmd.Connection.Open();
            int retval = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return retval;
        }
        public SqlDataReader GetReader(string Query)
        {
            SqlCommand cmd = GetCommand(Query);
            cmd.Connection.Open();
            SqlDataReader retval = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return retval;
        }

        public DataTable GetTable(string Query)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = GetCommand(Query);
            cmd.Connection.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr != null && rdr.HasRows)
            {
                dt.Load(rdr);
            }
            cmd.Connection.Close();
            return dt;
        }
    }
}

