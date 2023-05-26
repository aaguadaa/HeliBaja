using Domain.Model;
using System.Collections.Generic;

namespace Business.Contracts
{
    public interface IUserService
    {
        Users GetUserByEmail(string email);
        List<Users> GetAllUsers();
        List<Booking> GetUserBookings(int userId);
        List<Flight> GetAvailableFlights();
        bool BookFlight(int userId, int flightId);
        bool CancelBooking(int bookingId);
        List<Users> GetAdminUsers();
        Users Get(int userId);
        int Add(Users user);
        bool Update(Users user);
        bool Delete(int userId);
    }
}