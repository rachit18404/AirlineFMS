using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class AdminDao
    {
        SqlCommand command = null;
        string Qry = string.Empty;
        SqlConnection connection = new SqlConnection(@"Data Source=HYD-5DVP2N3\SQLEXPRESS;Initial Catalog=AMS;Integrated Security=True");
        public Admin AdminLogin(string email, string password)
        {
            Admin admin = new Admin();
            try
            {
                Qry = "GetAdmin_SP";
                command = new SqlCommand(Qry, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    admin.adminId = (int)reader["adminId"];
                    admin.password = reader["password"].ToString();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return admin;
        }
    }
}
