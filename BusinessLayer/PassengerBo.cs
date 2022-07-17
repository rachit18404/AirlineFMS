using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Models;
using DataLayer;
namespace BusinessLayer
{
    public class PassengerBo
    {
        private PassengerDao passengerDao;
        public PassengerBo()
        {
            passengerDao = new PassengerDao();
        }
        public void AddPassenger(Passenger passenger)
        {
            try
            {
                passengerDao.AddPassenger(passenger);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<Passenger> GetAllPassengers()
        {
            List<Passenger> passengers = new List<Passenger>();
            try
            {
                passengers=passengerDao.GetAllPassengers();
            }
            catch(Exception ex)
            {
                throw;
            }
            return passengers;
        }

    }
}
