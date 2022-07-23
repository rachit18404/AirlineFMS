using Models;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using System.Collections;

namespace BusinessLayer
{
     public class BookingBo
    {
        private BookingDao bookingDao;
        private FlightDao flightDao;
        private PaymentDao paymentDao;
        public BookingBo()
        {
            bookingDao = new BookingDao();
            flightDao = new FlightDao();
            paymentDao = new PaymentDao();
        }
        public void AddBooking(Booking booking)
        {
            try
            {
                var flight = flightDao.GetFlightbyFlightId(booking.flightId);
                long price = 0;
                if (booking.className == "business")
                {
                    price = booking.seatNo * flight.businessPrice;
                }
                else
                {
                    price = booking.seatNo * flight.economyPrice;
                }
                var payment = new Payment()
                {
                    passengerId = booking.passengerId,
                    amount = price,
                    paymentStatus= "success"
                };
                paymentDao.AddPayment(payment);
                bookingDao.AddBooking(booking);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<Booking> GetAllBookings()
        {
            List<Booking> bookings = new List<Booking>();
            try
            {
                bookings = bookingDao.GetAllBookings();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bookings;
        }

        public List<Hashtable> GetBookingsByPassengerId(int passengerId)
        {
            List<Hashtable> bookings = new List<Hashtable>();
            try
            {
                bookings = bookingDao.GetBookingsByPassengerId(passengerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bookings;
        }

    }
}

