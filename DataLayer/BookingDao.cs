using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Models;

namespace DataLayer
{
    public class BookingDao
    {
        SqlCommand command = null;
        string Qry = string.Empty;
        SqlConnection connection = new SqlConnection(@"Data Source=HYD-CDVP2N3\SQLEXPRESS01;Initial Catalog=AMS;Integrated Security=True");

        public void AddBooking(Booking booking)
        {
            try
            {
                Qry = "BookFlight_SP";
                command = new SqlCommand(Qry, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@flightId", booking.flightId);
                command.Parameters.AddWithValue("@passengerId", booking.passengerId);
                command.Parameters.AddWithValue("@className", booking.className);
                command.Parameters.AddWithValue("@seatNo", booking.seatNo);
                command.Parameters.AddWithValue("@flightdate", booking.flightDate);

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

