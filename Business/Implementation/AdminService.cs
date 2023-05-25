using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;

namespace Business.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IUserRepository _userRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IAgendaRepository _agendaRepository;

        public AdminService(IAdminRepository adminRepository, IBookingRepository bookingRepository, IFlightRepository flightRepository,
                            IUserRepository userRepository, IInventoryRepository inventoryRepository, IAgendaRepository agendaRepository)
        {
            _adminRepository = adminRepository;
            _bookingRepository = bookingRepository;
            _flightRepository = flightRepository;
            _userRepository = userRepository;
            _inventoryRepository = inventoryRepository;
            _agendaRepository = agendaRepository;
        }

        public int AddAdmin(Admin admin)
        {
            throw new System.NotImplementedException();
        }

        public bool AddAdminFlight(Flight flight)
        {
            throw new System.NotImplementedException();
        }

        public int AddAgenda(Agenda agenda)
        {
            throw new System.NotImplementedException();
        }

        public bool AssignFlightToPilot(int pilotId, int flightId)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteAdmin(int adminId)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteAdminFlight(int flightId)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteAgenda(int agendaId)
        {
            throw new System.NotImplementedException();
        }

        public List<Booking> GetAdminBookings()
        {
            throw new System.NotImplementedException();
        }

        public Admin GetAdminById(int adminId)
        {
            throw new System.NotImplementedException();
        }

        public Flight GetAdminFlightById(int flightId)
        {
            throw new System.NotImplementedException();
        }

        public List<Flight> GetAdminFlights()
        {
            throw new System.NotImplementedException();
        }

        public List<Inventory> GetAdminInventory()
        {
            throw new System.NotImplementedException();
        }

        public List<Users> GetAdminUsers()
        {
            throw new System.NotImplementedException();
        }

        public Agenda GetAgendaById(int agendaId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Agenda> GetAgendasByFlightId(int flightId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Agenda> GetAgendasByPilotId(int pilotId)
        {
            throw new System.NotImplementedException();
        }

        public Pilots GetPilotById(int pilotId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Pilots> GetPilots()
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateAdmin(Admin admin)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateAdminBooking(Booking booking)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateAdminFlight(Flight flight)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateAgenda(Agenda agenda)
        {
            throw new System.NotImplementedException();
        }
    }
}
