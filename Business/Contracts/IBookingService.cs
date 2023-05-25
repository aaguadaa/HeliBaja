using Domain.Model;
using System.Collections.Generic;

namespace Business.Contracts
{
    public interface IBookingService
    {
        int AddBooking(Booking booking);
        bool UpdateBooking(Booking booking);
        bool DeleteBooking(int bookingId);
        Booking GetBookingById(int bookingId);
        List<Booking> GetBookingsByClientId(int clientId);
        List<Booking> GetBookingsByFlightId(int flightId);
        List<Booking> GetAllBookings();
    }
}