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
        public List<Booking> GetAllBookings()
        {
            List<Booking> bookings = new List<Booking>();
            try
            {
                Qry = "GetBookingDetails_SP";
                command = new SqlCommand(Qry, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Booking booking = new Booking();
                        booking.bookingId = (int)reader["bookingId"];
                        booking.flightId = (int)reader["flightId"];
                        booking.passengerId = (int)reader["passengerId"];
                        booking.className = reader["className"].ToString();
                        booking.seatNo = (int)reader["seatNo"];
                        booking.flightDate =  Convert.ToDateTime(reader["flightDate"].ToString());
                       
                        bookings.Add(booking);

      
                     }
                }
                else
                    Console.WriteLine("NO bookings");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return bookings;
        }
    }
}

