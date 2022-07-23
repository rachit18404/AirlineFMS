using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Models;
namespace DataLayer
{
    public class PassengerDao
    {
        SqlCommand command = null;
        string Qry = string.Empty;
        SqlConnection connection = new SqlConnection(@"Data Source=HYD-5DVP2N3\SQLEXPRESS;Initial Catalog=AMS;Integrated Security=True");

        public void AddPassenger(Passenger passenger)
        {
          try
            {
                Qry = "AddPassenger_SP";
                command = new SqlCommand(Qry, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
               
                command.Parameters.AddWithValue("@email", passenger.email);
                command.Parameters.AddWithValue("@password",passenger.password);
                command.Parameters.AddWithValue("@name", passenger.name);
                command.Parameters.AddWithValue("@phone", passenger.phone);
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

        public List<Passenger> GetAllPassengers()
        {
            List<Passenger> passengers = new List<Passenger>();
            try
            {
                Qry = "GetPassengerDetails_SP";
                command = new SqlCommand(Qry, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Passenger passenger = new Passenger();
                        passenger.passengerId= (int)reader[0];
                        passenger.name = reader[3].ToString();
                        passenger.email = reader[1].ToString();
                        passenger.password = reader[2].ToString();
                        passenger.phone = (long)reader[4];
                        //string row = $"eid:{reader[0]} ename:{reader[1]} projectCode:{reader[2]} salary:{reader[3]}";
                        //Console.WriteLine(row);
                        passengers.Add(passenger);
                    }
                }
                else
                    Console.WriteLine("NO Passengers");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return passengers;
        }

        public Passenger PassengerLogin(string email, string password)
        {
            Passenger p = new Passenger();
            try
            {
                Qry = "GetPassenger_SP";
                command = new SqlCommand(Qry, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p.passengerId = (int)reader["passengerId"];
                    p.name = reader["name"].ToString();
                    p.email = reader["email"].ToString();
                    p.password = reader["password"].ToString();
                    p.phone = (long)reader["phone"];
                }
                else
                {
                    return null;
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return p;
        }
        public void UpdatePassengerInfo(Passenger passenger)
        {
            try
            {
                Qry = $"EditPassengerinfo_SP";
                command = new SqlCommand(Qry, connection);
                command.Parameters.AddWithValue("@passengerId", passenger.passengerId);
                command.Parameters.AddWithValue("@passengerName", passenger.name);
                command.Parameters.AddWithValue("@passengerPassword", passenger.password);
                command.Parameters.AddWithValue("@emailId", passenger.email);
                command.Parameters.AddWithValue("@phoneNo", passenger.phone);
               
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

    }
}
