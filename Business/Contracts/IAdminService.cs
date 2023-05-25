using Domain.Model;
using System.Collections.Generic;

namespace Business.Contracts
{
    public interface IAdminService
    {
        // Métodos para Admin
        Admin GetAdminById(int adminId);
        int AddAdmin(Admin admin);
        bool UpdateAdmin(Admin admin);
        bool DeleteAdmin(int adminId);

        // Métodos para Booking
        List<Booking> GetAdminBookings();
        bool UpdateAdminBooking(Booking booking);

        // Métodos para Flight
        List<Flight> GetAdminFlights();
        Flight GetAdminFlightById(int flightId);
        bool AddAdminFlight(Flight flight);
        bool UpdateAdminFlight(Flight flight);
        bool DeleteAdminFlight(int flightId);

        // Métodos para User
        List<Users> GetAdminUsers();

        // Métodos para Inventory
        List<Inventory> GetAdminInventory();

        // Métodos para Agenda
        int AddAgenda(Agenda agenda);
        bool UpdateAgenda(Agenda agenda);
        bool DeleteAgenda(int agendaId);
        Agenda GetAgendaById(int agendaId);
        IEnumerable<Agenda> GetAgendasByPilotId(int pilotId);
        IEnumerable<Agenda> GetAgendasByFlightId(int flightId);

        // Métodos para Pilot
        IEnumerable<Pilots> GetPilots();
        Pilots GetPilotById(int pilotId);
        bool AssignFlightToPilot(int pilotId, int flightId);
    }
}