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
    }
}
