using System;
using Models;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DataLayer
{
    public class FlightDao
    {
        SqlCommand command = null;
        string Qry = string.Empty;
        SqlConnection connection = new SqlConnection(@"Data Source=HYD-CDVP2N3\SQLEXPRESS01;Initial Catalog=AMS;Integrated Security=True");

        public void AddFlight(Flight flight)
        {
            try
            {
                Qry = "Add_Flight_SP";
                command = new SqlCommand(Qry, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@SourceAddress", flight.sourceAddress);
                command.Parameters.AddWithValue("@DestinationAddress", flight.destinationAddress);
                command.Parameters.AddWithValue("@DepartureTime", flight.departuretTime);
                command.Parameters.AddWithValue("@ArrivalTime", flight.arrivalTime);

                command.Parameters.AddWithValue("@Price", flight.price);
                command.Parameters.AddWithValue("@FlightName", flight.flightName);
                command.Parameters.AddWithValue("@Business_seat_price", flight.business_seat_price);
                command.Parameters.AddWithValue("@Economy_seat_price", flight.economy_seat_price);
                command.Parameters.AddWithValue("@Business_seat", flight.business_seat);
                command.Parameters.AddWithValue("@Economy_seat", flight.economy_seat);
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
        public List<Flight> SearchFlight(string sourceAddress, string destinationAddress)
        {
            List<Flight> flights = new List<Flight>();
            try
            {
                Qry = "SearchFlight_SP";
                command = new SqlCommand(Qry, connection);
                command.Parameters.AddWithValue("@sourceAddress", sourceAddress);
                command.Parameters.AddWithValue("@destinationAddress", destinationAddress);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Flight flight = new Flight();
                        flight.flightId = (int)reader["flightId"];
                        flight.arrivalTime = reader["arrivalTime"].ToString();
                        flight.sourceAddress = reader["sourceAddress"].ToString();
                        flight.destinationAddress = reader["destinationAddress"].ToString();
                        flight.departuretTime = reader["departureTime"].ToString();
                        flight.price = (long)reader["price"];
                        flight.flightName = reader["flightName"].ToString();
                        flight.business_seat_price = (long)reader["business_seat_price"];
                        flight.economy_seat_price = (long)reader["economy_seat_price"];
                        flight.business_seat = (int)reader["business_seat"];
                        flight.economy_seat = (int)reader["economy_seat"];
                        //string row = $"eid:{reader[0]} ename:{reader[1]} projectCode:{reader[2]} salary:{reader[3]}";
                        //Console.WriteLine(row);
                        flights.Add(flight);
                    }
                }
                else
                    Console.WriteLine("NO flights available");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return flights;
        }
    }
}

  
