using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IFlightRepository : IGenericRepository<Flight>
    {
        Task<IEnumerable<Flight>> GetFlightsByPilotId(int pilotId);
        Task<IEnumerable<Flight>> GetFlightsByDate(DateTime date);
        Task<IEnumerable<Flight>> GetFlightsByDateRange(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Flight>> GetFlightsByStatus(string status);
        Task<IEnumerable<Flight>> GetFlightsByBookingId(int bookingId);
        List<Flight> GetAdminFlights();
        List<Flight> GetFlights();
        List<Flight> GetAllFlights();
        List<Flight> GetAvailableFlights();
    }
}