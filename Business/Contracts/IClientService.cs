using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IClientService
    {
        int AddClient(Clients client);
        bool DeleteClient(int clientId);
        Clients GetClientById(int clientId);
        Clients GetClientByEmail(string email);
        Clients GetClientByCredentials(string email, string password);
        bool UpdateClient(Clients client);
        List<Flight> GetAvailableFlights();
        Flight GetFlightDetails(int flightId);
        bool CreateBooking(Booking booking);
        bool UpdateBooking(Booking booking);
        bool DeleteBooking(int bookingId);
        bool CancelBooking(int bookingId);
        List<Booking> GetAllBookingsByClientId(int clientId);
        bool Login(string email, string password);
        void Logout();
        bool RecoverAccount(string email);
    }
}