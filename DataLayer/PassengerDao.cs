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
        SqlConnection connection = new SqlConnection(@"Data Source=MUM02L10248\SQLEXPRESS;Initial Catalog=AMS;User ID=sa;Password=Password123");

        public void AddPassenger(Passenger passenger)
        {
          try
            {
                Qry = "Add_Passenger_SP";
                command = new SqlCommand(Qry, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PassengerId", passenger.passengerId);
                command.Parameters.AddWithValue("@EmailId", passenger.emailId);
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
                Qry = "Get_Passengers_SP";
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
                        passenger.passengerName = reader[1].ToString();
                        passenger.emailId = reader[2].ToString();
                        passenger.phoneNo = (long)reader[3];
                        //string row = $"eid:{reader[0]} ename:{reader[1]} projectCode:{reader[2]} salary:{reader[3]}";
                        //Console.WriteLine(row);
                        passengers.Add(passenger);
                    }
                }
                else
                    Console.WriteLine("NO Proudcts");
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

    }
}
