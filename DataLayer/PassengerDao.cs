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
        SqlConnection connection = new SqlConnection(@"Data Source=HYD-CDVP2N3\SQLEXPRESS01;Initial Catalog=AMS;Integrated Security=True");

        public void AddPassenger(Passenger passenger)
        {
          try
            {
                Qry = "AddPassenger_SP";
                command = new SqlCommand(Qry, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
               
                command.Parameters.AddWithValue("@EmailId", passenger.emailId);
                command.Parameters.AddWithValue("@PassengerPassword",passenger.passengerPassword);
                command.Parameters.AddWithValue("@PassengerName", passenger.passengerName);
                command.Parameters.AddWithValue("@PhoneNo", passenger.phoneNo);
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
                        passenger.passengerName = reader[3].ToString();
                        passenger.emailId = reader[1].ToString();
                        passenger.passengerPassword = reader[2].ToString();
                        passenger.phoneNo = (long)reader[4];
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

        public Passenger GetByLogin(Passenger passenger)
        {
            Passenger p = new Passenger();
            try
            {
                Qry = "GetPassenger_SP";
                command = new SqlCommand(Qry, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@email", passenger.emailId);
                command.Parameters.AddWithValue("@password", passenger.passengerPassword);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p.passengerId = (int)reader[0];
                    p.passengerName = reader[3].ToString();
                    p.emailId = reader[1].ToString();
                    p.passengerPassword = reader[2].ToString();
                    p.phoneNo = (long)reader[4];
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

    }
}
