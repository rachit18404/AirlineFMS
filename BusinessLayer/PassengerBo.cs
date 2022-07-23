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
                return passengers;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return passengers;
        }
        public Passenger Passenger1Login(Passenger passenger)
        {
            Passenger p=new Passenger();
            try
            {
                p = passengerDao.PassengerLogin(passenger.email, passenger.password);
                if (p!=null)
                {
                    return p;
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void UpdatePassengerInfo(Passenger passenger)
        {
            try
            {
                passengerDao.UpdatePassengerInfo(passenger);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
