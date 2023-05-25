using System.Collections.Generic;
using Domain.Model;

namespace Data.Contracts
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        List<Booking> GetAdminBookings();
        bool UpdateAdminBooking(Booking booking);
        List<Flight> GetAdminFlights();
        Flight GetAdminFlightById(int flightId);
        bool AddAdminFlight(Flight flight);
        bool UpdateAdminFlight(Flight flight);
        bool DeleteAdminFlight(int flightId);
        List<Users> GetAdminUsers();
        List<Inventory> GetAdminInventory();
        int AddAgenda(Agenda agenda);
        bool UpdateAgenda(Agenda agenda);
        bool DeleteAgenda(int agendaId);
        Agenda GetAgendaById(int agendaId);
        IEnumerable<Agenda> GetAgendasByPilotId(int pilotId);
        IEnumerable<Agenda> GetAgendasByFlightId(int flightId);

        IEnumerable<Pilots> GetPilots();
        Pilots GetPilotById(int pilotId);
        bool AssignFlightToPilot(int pilotId, int flightId);
    }
}