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
        SqlConnection connection = new SqlConnection(@"Data Source=HYD-5DVP2N3\SQLEXPRESS;Initial Catalog=AMS;Integrated Security=True");

        public void AddFlight(Flight flight)
        {
            try
            {
                Qry = "Add_Flight_SP";
                command = new SqlCommand(Qry, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@source", flight.source);
                command.Parameters.AddWithValue("@destination", flight.destination);
                command.Parameters.AddWithValue("@departureTime", flight.departureTime);
                command.Parameters.AddWithValue("@arrivalTime", flight.arrivalTime);

             
                command.Parameters.AddWithValue("@name", flight.name);
                command.Parameters.AddWithValue("@businessPrice", flight.businessPrice);
                command.Parameters.AddWithValue("@economyPrice", flight.economyPrice);
                command.Parameters.AddWithValue("@businessSeat", flight.businessSeat);
                command.Parameters.AddWithValue("@economySeat", flight.economySeat);
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
        public List<Flight> SearchFlight(string source, string destination)
        {
            List<Flight> flights = new List<Flight>();
            try
            {
                Qry = "SearchFlight_SP";
                command = new SqlCommand(Qry, connection);
                command.Parameters.AddWithValue("@source", source);
                command.Parameters.AddWithValue("@destination", destination);
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
                        flight.source = reader["source"].ToString();
                        flight.destination = reader["destination"].ToString();
                        flight.departureTime = reader["departureTime"].ToString();    
                        flight.name = reader["name"].ToString();
                        flight.businessPrice = (long)reader["businessPrice"];
                        flight.economyPrice = (long)reader["economyPrice"];
                        flight.businessSeat = (int)reader["businessSeat"];
                        flight.economySeat = (int)reader["economySeat"];
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
        public void DeleteFlight(int flightId)
        {
            try
            {
                Qry = $"DeleteFlightByFlightId_SP {flightId}";
                command = new SqlCommand(Qry, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
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
        public List<Flight> GetAllFlights()
        {
            List<Flight>flights = new List<Flight>();
            try
            {
                Qry = "Get_All_Flights_SP";
                command = new SqlCommand(Qry, connection);
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
                        flight.source = reader["source"].ToString();
                        flight.destination = reader["destination"].ToString();
                        flight.departureTime = reader["departureTime"].ToString();

                        flight.name = reader["name"].ToString();
                        flight.businessPrice = (long)reader["businessPrice"];
                        flight.economyPrice = (long)reader["economyPrice"];
                        flight.businessSeat = (int)reader["businessSeat"];
                        flight.economySeat = (int)reader["economySeat"];
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
        public void EditFlight(Flight flight)
        {
            try
            {
                Qry = $"EditFlight_SP";
                command = new SqlCommand(Qry, connection);
                command.Parameters.AddWithValue("@flightId", flight.flightId);
                command.Parameters.AddWithValue("@name", flight.name);
                command.Parameters.AddWithValue("@source", flight.source);
                command.Parameters.AddWithValue("@destination", flight.destination);
                command.Parameters.AddWithValue("@departureTime", flight.departureTime);
                command.Parameters.AddWithValue("@arrivalTime", flight.arrivalTime);
                command.Parameters.AddWithValue("@businessPrice", flight.businessPrice);
                command.Parameters.AddWithValue("@economyPrice", flight.economyPrice);
                command.Parameters.AddWithValue("@businessSeat", flight.businessSeat);
                command.Parameters.AddWithValue("@economySeat", flight.economySeat);
                command.CommandType = System.Data.CommandType.StoredProcedure;
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
        public Flight GetFlightbyFlightId(int flightId)
        {
            Flight flight = new Flight();
            try
            {
                Qry = "GetFlightByFlightId_SP";
                command = new SqlCommand(Qry, connection);
                command.Parameters.AddWithValue("@flightId", flightId);
               
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                       
                        flight.flightId = (int)reader["flightId"];
                        flight.arrivalTime = reader["arrivalTime"].ToString();
                        flight.source = reader["source"].ToString();
                        flight.destination = reader["destination"].ToString();
                        flight.departureTime = reader["departureTime"].ToString();

                        flight.name = reader["name"].ToString();
                        flight.businessPrice = (long)reader["businessPrice"];
                        flight.economyPrice = (long)reader["economyPrice"];
                        flight.businessSeat = (int)reader["businessSeat"];
                        flight.economySeat = (int)reader["economySeat"];
                        //string row = $"eid:{reader[0]} ename:{reader[1]} projectCode:{reader[2]} salary:{reader[3]}";
                        //Console.WriteLine(row);
                      
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
            return flight;
        }

    }
}

  
