using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly HeliBajaDBContext _dbContext;

        public ClientRepository(HeliBajaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Clients entity)
        {
            _dbContext.Clients.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id_Client;
        }

        public bool Delete(int id)
        {
            var client = _dbContext.Clients.FirstOrDefault(c => c.Id_Client == id);
            if (client == null)
            {
                return false;
            }
            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();
            return true;
        }

        public Clients Get(int id)
        {
            return _dbContext.Clients.FirstOrDefault(c => c.Id_Client == id);
        }

        public IEnumerable<Clients> GetAll()
        {
            return _dbContext.Clients.ToList();
        }

        public bool Update(Clients entity)
        {
            var existingClient = _dbContext.Clients.FirstOrDefault(c => c.Id_Client == entity.Id_Client);
            if (existingClient == null)
            {
                return false;
            }
            existingClient.Name = entity.Name;
            existingClient.APaterno = entity.APaterno;
            existingClient.AMaterno = entity.AMaterno;
            existingClient.Email = entity.Email;
            existingClient.Password = entity.Password;
            _dbContext.SaveChanges();
            return true;
        }

        public Clients GetClientById(int clientId)
        {
            return _dbContext.Clients.FirstOrDefault(c => c.Id_Client == clientId);
        }

        public Clients GetClientByEmail(string email)
        {
            return _dbContext.Clients.FirstOrDefault(c => c.Email == email);
        }

        public Clients GetClientByCredentials(string email, string password)
        {
            return _dbContext.Clients.FirstOrDefault(c => c.Email == email && c.Password == password);
        }

        public List<Flight> GetAvailableFlights()
        {
            return _dbContext.Flights.ToList();
        }

        public Flight GetFlightDetails(int flightId)
        {
            return _dbContext.Flights.FirstOrDefault(f => f.Id_Flight == flightId);
        }

        public bool CreateBooking(Booking booking)
        {
            _dbContext.Bookings.Add(booking);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateBooking(Booking booking)
        {
            var existingBooking = _dbContext.Bookings.FirstOrDefault(b => b.Id_Booking == booking.Id_Booking);
            if (existingBooking == null)
            {
                return false;
            }
            existingBooking.CreatedDate = booking.CreatedDate;
            existingBooking.Id_Flight = booking.Id_Flight;
            existingBooking.Id_Client = booking.Id_Client;
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteBooking(int bookingId)
        {
            var booking = _dbContext.Bookings.FirstOrDefault(b => b.Id_Booking == bookingId);
            if (booking == null)
            {
                return false;
            }
            _dbContext.Bookings.Remove(booking);
            _dbContext.SaveChanges();
            return true;
        }

        public bool CancelBooking(int bookingId)
        {
            var booking = _dbContext.Bookings.FirstOrDefault(b => b.Id_Booking == bookingId);
            if (booking == null)
            {
                return false;
            }

            // Verificar si el tour está dentro del límite de cancelación (2 días antes)
            var twoDaysBeforeTour = booking.TourDate.AddDays(-2);
            if (twoDaysBeforeTour <= System.DateTime.Now)
            {
                return false;
            }

            _dbContext.Bookings.Remove(booking);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Booking> GetAllBookingsByClientId(int clientId)
        {
            return _dbContext.Bookings.Where(b => b.Id_Client == clientId).ToList();
        }

        public bool Login(string email, string password)
        {
            var client = _dbContext.Clients.FirstOrDefault(c => c.Email == email && c.Password == password);
            return client != null;
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }

        public bool RecoverAccount(string email)
        {
            Clients client = GetClientByEmail(email);

            /*if (client != null)
            {
                // Generar una nueva contraseña o enviar instrucciones para restablecer la contraseña
                string newPassword = GenerateNewPassword();

                // Enviar un correo electrónico con instrucciones detalladas para el restablecimiento de la cuenta
                SendRecoveryEmail(client.Email, newPassword);

                return true; // La recuperación de la cuenta fue exitosa
            }*/
            return false;
        }

        public Booking GetBookingById(int bookingId)
        {
            return _dbContext.Bookings.FirstOrDefault(b => b.Id_Booking == bookingId);
        }
    }
}