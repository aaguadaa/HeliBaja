using System.Collections.Generic;
using System.Linq;
using Data.Contracts;
using Domain.Model;

namespace Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly List<Admin> _admins;
        private readonly List<Booking> _bookings;
        private readonly List<Flight> _flights;
        private readonly List<Users> _users;
        private readonly List<Inventory> _inventory;
        private readonly List<Agenda> _agenda;
        private readonly List<Pilots> _pilot;

        public AdminRepository()
        {
            // Inicializar datos de ejemplo
            _admins = new List<Admin>();
            _bookings = new List<Booking>();
            _flights = new List<Flight>();
            _users = new List<Users>();
            _inventory = new List<Inventory>();
            _agenda = new List<Agenda>();
            _pilot = new List<Pilots>();
        }

        // Implementación de métodos para Admin
        public Admin GetAdminById(int adminId)
        {
            return _admins.FirstOrDefault(a => a.Id == adminId);
        }
        public int Add(Admin entity)
        {
            _admins.Add(entity);
            return entity.Id;
        }
        public Admin Get(int id)
        {
            return _admins.FirstOrDefault(a => a.Id == id);
        }
        public bool Update(Admin entity)
        {
            var existingAdmin = _admins.FirstOrDefault(a => a.Id == entity.Id);
            if (existingAdmin == null)
            {
                return false; // El admin no existe, no se puede actualizar
            }

            existingAdmin.Name = entity.Name;
            existingAdmin.Email = entity.Email;

            return true;
        }
        public bool Delete(int id)
        {
            var admin = _admins.FirstOrDefault(a => a.Id == id);
            if (admin == null)
            {
                return false; // El admin no existe, no se puede eliminar
            }

            _admins.Remove(admin);
            return true;
        }
        // Implementación de métodos para Booking

        public List<Booking> GetAdminBookings()
        {
            return _bookings;
        }

        public bool UpdateAdminBooking(Booking booking)
        {
            var existingBooking = _bookings.FirstOrDefault(b => b.Id_Booking == booking.Id_Booking);
            if (existingBooking == null)
                return false;

            existingBooking.PaymentMethod = booking.PaymentMethod;
            existingBooking.PaymentStatus = booking.PaymentStatus;
            existingBooking.BookingStatus = booking.BookingStatus;

            return true;
        }

        // Implementación de métodos para Flight

        public List<Flight> GetAdminFlights()
        {
            return _flights;
        }

        public Flight GetAdminFlightById(int flightId)
        {
            return _flights.FirstOrDefault(f => f.Id_Flight == flightId);
        }

        public bool AddAdminFlight(Flight flight)
        {
            _flights.Add(flight);
            return true;
        }

        public bool UpdateAdminFlight(Flight flight)
        {
            var existingFlight = _flights.FirstOrDefault(f => f.Id_Flight == flight.Id_Flight);
            if (existingFlight == null)
                return false;

            existingFlight.Id_Flight = flight.Id_Flight;
            existingFlight.Destino = flight.Destino;
            // Actualizar otros campos según sea necesario

            return true;
        }

        public bool DeleteAdminFlight(int flightId)
        {
            var flight = _flights.FirstOrDefault(f => f.Id_Flight == flightId);
            if (flight == null)
                return false;

            _flights.Remove(flight);
            return true;
        }

        // Implementación de métodos para User

        public List<Users> GetAdminUsers()
        {
            return _users;
        }

        // Implementación de métodos para Inventory

        public List<Inventory> GetAdminInventory()
        {
            return _inventory;
        }

        // Implementación de métodos para Agenda

        public int AddAgenda(Agenda agenda)
        {
            _agenda.Add(agenda);
            return agenda.Id_Agenda;
        }

        public bool UpdateAgenda(Agenda agenda)
        {
            var existingAgenda = _agenda.FirstOrDefault(a => a.Id_Agenda == agenda.Id_Agenda);
            if (existingAgenda == null)
            {
                return false; // La agenda no existe, no se puede actualizar
            }

            existingAgenda.Id_Pilot = agenda.Id_Pilot;
            existingAgenda.Id_Flight = agenda.Id_Flight;
            // Actualizar otros campos según sea necesario

            return true;
        }

        public bool DeleteAgenda(int agendaId)
        {
            var agenda = _agenda.FirstOrDefault(a => a.Id_Agenda == agendaId);
            if (agenda == null)
            {
                return false; // La agenda no existe, no se puede eliminar
            }

            _agenda.Remove(agenda);
            return true;
        }

        public Agenda GetAgendaById(int agendaId)
        {
            return _agenda.FirstOrDefault(a => a.Id_Agenda == agendaId);
        }

        public IEnumerable<Agenda> GetAgendasByPilotId(int pilotId)
        {
            return _agenda.Where(a => a.Id_Pilot == pilotId);
        }

        public IEnumerable<Agenda> GetAgendasByFlightId(int flightId)
        {
            return _agenda.Where(a => a.Id_Flight == flightId);
        }

        public IEnumerable<Pilots> GetPilots()
        {
            return _pilot;
        }

        public Pilots GetPilotById(int pilotId)
        {
            return _pilot.FirstOrDefault(p => p.Id_Pilot == pilotId);
        }

        public bool AssignFlightToPilot(int pilotId, int flightId)
        {
            var pilot = _pilot.FirstOrDefault(p => p.Id_Pilot == pilotId);
            var flight = _flights.FirstOrDefault(f => f.Id_Flight == flightId);

            if (pilot == null || flight == null)
            {
                return false; // El piloto o el vuelo no existen
            }

            var agenda = new Agenda
            {
                Id_Pilot = pilotId,
                Id_Flight = flightId
            };

            _agenda.Add(agenda);
            return true;
        }

    }
}