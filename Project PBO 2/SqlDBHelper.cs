using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Project_PBO_2
{
    public class SqlDBHelper
    {
        public DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = sql; //"Select * from student";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    //GridView1.DataSource = dt;
                    //GridView1.DataBind();
                }
            }
            catch (Exception ex) { }
            return dt;
        }

        public void ExecuteQuery(ref DataTable dt, string sql)
        {
            //DataTable dt = new DataTable();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = sql; //"Select * from student";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    //GridView1.DataSource = dt;
                    //GridView1.DataBind();
                }
            }
            catch (Exception ex) { }
            //return dt;
        }


        public DataTable ExecuteQuery(string sql, params NpgsqlParameter[] parameters)
        {
            using (DataSet ds = new DataSet())
            using (NpgsqlConnection connStr = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connStr))
            {

                //cmd.CommandType = cmdType;
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }

                try
                {
                    cmd.Connection.Open();
                    new NpgsqlDataAdapter(cmd).Fill(ds);
                }
                catch (NpgsqlException ex)
                {
                    //Show a message or log a message on ex.Message
                }
                return ds.Tables[0];
            }
        }


        public void ExecuteNonQuery(string sql, params NpgsqlParameter[] parameters)
        {
            using (DataSet ds = new DataSet())
            using (NpgsqlConnection connStr = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connStr))
            {

                //cmd.CommandType = cmdType;
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }

                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                    connStr.Close();
                    //new NpgsqlDataAdapter(cmd).Fill(ds);
                }
                catch (NpgsqlException ex)
                {
                    //Show a message or log a message on ex.Message
                }
                //return ds.Tables[0];
            }
        }


        public void ExecuteNonQuery(string query)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    //string query = "Delete from student where nim=@nim";
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
