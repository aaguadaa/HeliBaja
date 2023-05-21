using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class AdminRepository : IAdminRepository
    {
        private readonly HeliBajaDBContext _context;

        public AdminRepository(HeliBajaDBContext context)
        {
            _context = context;
        }

        public int Add(Admin entity)
        {
            _context.Admin.Add(entity);
            return _context.SaveChanges();
        }

        public bool Update(Admin entity)
        {
            var admin = _context.Admin.Find(entity.Id);
            if (admin == null)
                return false;

            admin.Name = entity.Name;
            admin.Email = entity.Email;
            admin.Password = entity.Password;
            admin.Inventories = entity.Inventories;

            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var admin = _context.Admin.Find(id);
            if (admin == null)
                return false;

            _context.Admin.Remove(admin);
            return _context.SaveChanges() > 0;
        }

        public Admin Get(int id)
        {
            return _context.Admin.Find(id);
        }

        public List<Booking> GetBookings()
        {
            return _context.Bookings.ToList();
        }

        public List<Flight> GetFlights()
        {
            return _context.Flights.ToList();
        }

        public bool AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateBooking(Booking booking)
        {
            var existingBooking = _context.Bookings.Find(booking.Id_Booking);
            if (existingBooking == null)
                return false;

            existingBooking.Id_Client = booking.Id_Client;
            existingBooking.Id_Flight = booking.Id_Flight;


            return _context.SaveChanges() > 0;
        }

        public bool DeleteBooking(int Id_Booking)
        {
            var booking = _context.Bookings.Find(Id_Booking);
            if (booking == null)
                return false;

            _context.Bookings.Remove(booking);
            return _context.SaveChanges() > 0;
        }

        public bool AddFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateFlight(Flight flight)
        {
            var existingFlight = _context.Flights.Find(flight.Id_Flight);
            if (existingFlight == null)
                return false;

            existingFlight.NumeroVuelo = flight.NumeroVuelo;
            existingFlight.Origen = flight.Origen;
            existingFlight.Destino = flight.Destino;
            existingFlight.HoraSalida = flight.HoraSalida;
            existingFlight.HoraLlegada = flight.HoraLlegada;
            // ...

            return _context.SaveChanges() > 0;
        }


        public bool DeleteFlight(int Id_Flight)
        {
            var flight = _context.Flights.Find(Id_Flight);
            if (flight == null)
                return false;

            _context.Flights.Remove(flight);
            return _context.SaveChanges() > 0;
        }

        public bool AssignFlightToPilot(int flightId, int pilotId)
        {
            var flight = _context.Flights.Find(flightId);
            var pilot = _context.Pilots.Find(pilotId);
            if (flight == null || pilot == null)
                return false;

            pilot.Flights.Add(flight);
            return _context.SaveChanges() > 0;
        }

        public bool RemoveFlightFromPilot(int flightId, int pilotId)
        {
            var flight = _context.Flights.Find(flightId);
            var pilot = _context.Pilots.Find(pilotId);
            if (flight == null || pilot == null)
                return false;

            pilot.Flights.Remove(flight);
            return _context.SaveChanges() > 0;
        }
    }
}
