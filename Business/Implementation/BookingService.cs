using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Business.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public int AddBooking(Booking booking)
        {
            int bookingId = _bookingRepository.Add(booking);
            return bookingId;
        }

        public bool DeleteBooking(int bookingId)
        {
            bool isDeleted = _bookingRepository.Delete(bookingId);
            return isDeleted;
        }

        public List<Booking> GetAllBookings()
        {
            return _bookingRepository.GetAllBookings().ToList();
        }

        public Booking GetBookingById(int bookingId)
        {
            Booking booking = _bookingRepository.Get(bookingId);
            return booking;
        }

        public List<Booking> GetBookingsByClientId(int clientId)
        {
            List<Booking> bookings = _bookingRepository.GetBookingsByClientId(clientId).ToList();
            return bookings;
        }

        public List<Booking> GetBookingsByFlightId(int flightId)
        {
            List<Booking> bookings = _bookingRepository.GetBookingsByFlightId(flightId).ToList();
            return bookings;
        }

        public bool UpdateBooking(Booking booking)
        {
            bool isUpdated = _bookingRepository.Update(booking);
            return isUpdated;
        }
    }
}