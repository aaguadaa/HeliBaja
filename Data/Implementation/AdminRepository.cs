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
            _context.admin.Add(entity);
            return _context.SaveChanges();
        }

        public bool AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            return _context.SaveChanges() > 0;
        }

        public bool AddFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            return _context.SaveChanges() > 0;
        }

        public bool AddFlightToPilot(int Id_Flight, int Id_Pilot)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var admin = _context.admin.Find(id);
            if (admin == null)
                return false;

            _context.admin.Remove(admin);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteBooking(int Id_Booking)
        {
            var booking = _context.Bookings.Find(Id_Booking);
            if (booking == null)
            {
                return false;
            }

            _context.Bookings.Remove(booking);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteFlight(int Id_Flight)
        {
            var flight = _context.Flights.Find(Id_Flight);
            if (flight == null)
            {
                return false;
            }

            _context.Flights.Remove(flight);
            return _context.SaveChanges() > 0;
        }

        public Admin Get(int id)
        {
            return _context.admin.Find(id);
        }

        public List<Booking> GetBooking()
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetBookings()
        {
            return _context.Bookings.ToList();
        }

        public List<Flight> GetFlights()
        {
            return _context.Flights.ToList();
        }

        public bool RemoveFlightFromPilot(int Id_flight, int Id_Pilot)
        {
            var pilot = _context.Pilots.Find(Id_Pilot);
            if (pilot == null)
            {
                return false;
            }

            var flight = pilot.Flights.FirstOrDefault(v => v.Id_Flight == Id_flight);
            if (flight == null)
            {
                return false;
            }

            pilot.Flights.Remove(flight);
            return _context.SaveChanges() > 0;
        }

        public bool Update(Admin entity)
        {
            var admin = _context.admin.Find(entity.Id);
            if (admin == null)
                return false;

            admin.Name = entity.Name;
            admin.Email = entity.Email;
            admin.Password = entity.Password;
            admin.Inventories = entity.Inventories;

            return _context.SaveChanges() > 0;
        }

        public bool UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public bool UpdateFlight(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
