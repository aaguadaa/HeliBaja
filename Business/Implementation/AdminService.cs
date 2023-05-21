using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;

namespace Business.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        // Booking
        public List<Booking> GetBookings()
        {
            return _adminRepository.GetBookings();
        }

        public bool AddBooking(Booking booking)
        {
            return _adminRepository.AddBooking(booking);
        }

        public bool UpdateBooking(Booking booking)
        {
            return _adminRepository.UpdateBooking(booking);
        }

        public bool DeleteBooking(int bookingId)
        {
            return _adminRepository.DeleteBooking(bookingId);
        }

        // Flight
        public List<Flight> GetFlights()
        {
            return _adminRepository.GetFlights();
        }

        public bool AddFlight(Flight flight)
        {
            return _adminRepository.AddFlight(flight);
        }

        public bool UpdateFlight(Flight flight)
        {
            return _adminRepository.UpdateFlight(flight);
        }

        public bool DeleteFlight(int flightId)
        {
            return _adminRepository.DeleteFlight(flightId);
        }

        public bool AssignFlightToPilot(int flightId, int pilotId)
        {
            return _adminRepository.AssignFlightToPilot(flightId, pilotId);
        }

        public bool RemoveFlightFromPilot(int flightId, int pilotId)
        {
            return _adminRepository.RemoveFlightFromPilot(flightId, pilotId);
        }
    }
}
