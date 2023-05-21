using System.Collections.Generic;
using Domain.Model;

namespace Data.Contracts
{
    public interface IUserRepository
    {
        int AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int userId);
        User GetUserById(int userId);
        User GetUserByEmail(string email);
        List<User> GetAllUsers();
        List<Booking> GetUserBookings(int userId);
        List<Flight> GetAvailableFlights();
        bool BookFlight(int userId, int flightId);
        bool CancelBooking(int bookingId);
    }
}