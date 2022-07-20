using System;
using System.Collections.Generic;
using DataLayer;
using Models;

namespace BusinessLayer
{
    public class FlightBo
    {
        private FlightDao flightDao;
        public FlightBo()
        {
            flightDao = new FlightDao();
        }
        public void AddFlight(Flight flight)
        {
            try
            {
                flightDao.AddFlight(flight);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<Flight> SearchFlight(string sourceAddress, string destinationAddress )
        {
            try
            {
                var flights = flightDao.SearchFlight(sourceAddress, destinationAddress);
                return flights;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void  DeleteFlight(int flightId)
        {
            try
            {
                flightDao.DeleteFlight(flightId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Flight> GetAllFlights()
        {
            List<Flight> flights = new List<Flight>();
            try
            {
                flights = flightDao.GetAllFlights();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flights;
        }
       public void EditFlight(Flight flight)
        {
            try
            {
                flightDao.EditFlight(flight);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Flight GetFlightbyFlightId(int flightId)
        {
            try
            {
                return flightDao.GetFlightbyFlightId(flightId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
