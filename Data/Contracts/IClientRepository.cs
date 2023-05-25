using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IClientRepository : IGenericRepository<Clients>
    {
        Clients GetClientById(int clientId);
        Clients GetClientByEmail(string email);
        Clients GetClientByCredentials(string email, string password);
        List<Flight> GetAvailableFlights();
        Flight GetFlightDetails(int flightId);
        bool CreateBooking(Booking booking);
        bool UpdateBooking(Booking booking);
        bool DeleteBooking(int bookingId);
        bool CancelBooking(int bookingId);
        Booking GetBookingById(int bookingId);
        List<Booking> GetAllBookingsByClientId(int clientId);
        bool Login(string email, string password);
        void Logout();
        bool RecoverAccount(string email);
    }
}