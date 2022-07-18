using Models;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;

namespace BusinessLayer
{
     public class BookingBo
    {
        private BookingDao bookingDao;
        public BookingBo()
        {
            bookingDao = new BookingDao();
        }
        public void AddBooking(Booking booking)
        {
            try
            {
                bookingDao.AddBooking(booking);
            }
            catch (Exception)
            {
                throw;
            }

        }
    

    }
}

