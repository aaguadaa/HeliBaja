using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Contracts;
using Domain.Model;

namespace Data.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly HeliBajaDBContext _context;

        public UserRepository(HeliBajaDBContext context)
        {
            _context = context;
        }

        public int Add(Users user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges();
        }

        public bool Update(Users user)
        {
            var existingUser = _context.Users.Find(user.Id);
            if (existingUser == null)
                return false;

            existingUser.Name = user.Name;
            existingUser.APaterno = user.APaterno;
            existingUser.AMaterno = user.AMaterno;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.PilotId = user.PilotId;
            existingUser.ClientId = user.ClientId;

            return _context.SaveChanges() > 0;
        }

        public bool Delete(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            return _context.SaveChanges() > 0;
        }

        public Users GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public List<Users> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public List<Booking> GetUserBookings(int userId)
        {
            return _context.Bookings.Where(b => b.Id_Client == userId).ToList();
        }

        public List<Flight> GetAvailableFlights()
        {
            return _context.Flights.ToList();
        }

        public bool BookFlight(int userId, int flightId)
        {
            var user = _context.Users.Find(userId);
            var flight = _context.Flights.Find(flightId);
            if (user == null || flight == null)
                return false;

            var booking = new Booking
            {
                Id_Client = userId,
                Id_Flight = flightId
            };

            _context.Bookings.Add(booking);
            return _context.SaveChanges() > 0;
        }
        public bool CancelBooking(int bookingId)
        {
            var booking = _context.Bookings.Find(bookingId);
            if (booking == null)
                return false;

            _context.Bookings.Remove(booking);
            return _context.SaveChanges() > 0;
        }

        public List<Users> GetAdminUsers()
        {
            return _context.Users.Where(u => u.PilotId == null && u.ClientId == null).ToList();
        }

        public Users GetAdminUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.PilotId == null && u.ClientId == null && u.Id == userId);
        }

        public bool AddAdminUser(Users user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateAdminUser(Users user)
        {
            _context.Entry(user).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool DeleteAdminUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.PilotId == null && u.ClientId == null && u.Id == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                return _context.SaveChanges() > 0;
            }
            return false;
        }
        public bool AssignUserType(int userId, UserType userType)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
                return false;

            if (userType == UserType.Pilot)
            {
                // Asignar el id del piloto al usuario
                var pilot = new Pilots();
                _context.Pilots.Add(pilot);
                _context.SaveChanges();

                user.PilotId = pilot.Id_Pilot;
                user.ClientId = null;
            }
            else if (userType == UserType.Client)
            {
                // Asignar el id del cliente al usuario
                var client = new Clients();
                _context.Clients.Add(client);
                _context.SaveChanges();

                user.PilotId = null;
                user.ClientId = client.Id_Client;
            }

            return _context.SaveChanges() > 0;
        }
        public Users Get(int id)
        {
            return _context.Users.Find(id);
        }
    }
}