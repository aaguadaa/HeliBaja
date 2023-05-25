using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Data.Implementation
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HeliBajaDBContext _dbContext;

        public BookingRepository(HeliBajaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Booking booking)
        {
            _dbContext.Bookings.Add(booking);
            _dbContext.SaveChanges();
            return booking.Id_Booking;
        }

        public bool Update(Booking booking)
        {
            var existingBooking = _dbContext.Bookings.FirstOrDefault(b => b.Id_Booking == booking.Id_Booking);
            if (existingBooking == null)
                return false;

            existingBooking.Id_Client = booking.Id_Client;
            existingBooking.Id_Client = booking.Id_Client;
            existingBooking.PaymentMethod = booking.PaymentMethod;
            existingBooking.PaymentStatus = booking.PaymentStatus;
            existingBooking.BookingStatus = booking.BookingStatus;

            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int bookingId)
        {
            var booking = _dbContext.Bookings.FirstOrDefault(b => b.Id_Booking == bookingId);
            if (booking == null)
                return false;

            _dbContext.Bookings.Remove(booking);
            _dbContext.SaveChanges();
            return true;
        }

        public Booking Get(int bookingId)
        {
            return _dbContext.Bookings.FirstOrDefault(b => b.Id_Booking == bookingId);
        }

        public IEnumerable<Booking> GetBookingsByClientId(int clientId)
        {
            return _dbContext.Bookings.Where(b => b.Id_Client == clientId).ToList();
        }

        public IEnumerable<Booking> GetBookingsByFlightId(int flightId)
        {
            return _dbContext.Bookings.Where(b => b.Id_Flight == flightId).ToList();
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _dbContext.Bookings.ToList();
        }
    }
}
