using Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IFlightService
    {
        int AddFlight(Flight flight);
        bool UpdateFlight(Flight flight);
        bool DeleteFlight(int flightId);
        Flight GetFlightById(int flightId);
        List<Flight> GetAdminFlights();
        List<Flight> GetFlights();
        Task<IEnumerable<Flight>> GetFlightsByBookingId(int bookingId);
        Task<IEnumerable<Flight>> GetFlightsByDate(DateTime date);
        Task<IEnumerable<Flight>> GetFlightsByDateRange(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Flight>> GetFlightsByPilotId(int pilotId);
        Task<IEnumerable<Flight>> GetFlightsByStatus(string status);
    }
}