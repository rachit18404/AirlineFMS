using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class PaymentDao
    {
        SqlCommand command = null;
        string Qry = string.Empty;
        SqlConnection connection = new SqlConnection(@"Data Source=HYD-5DVP2N3\SQLEXPRESS;Initial Catalog=AMS;Integrated Security=True");

        public void AddPayment(Payment payment)
        {
            try
            {
                Qry = "AddPayment_SP";
                command = new SqlCommand(Qry, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@amount", payment.amount);
                command.Parameters.AddWithValue("@passengerId", payment.passengerId);
                command.Parameters.AddWithValue("@paymentStatus", payment.paymentStatus);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
