using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public int AddClient(Clients client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            return _clientRepository.Add(client);

        }

        public bool CancelBooking(int bookingId)
        {
            if (bookingId <= 0)
                throw new ArgumentException("Invalid booking ID.");

            // Obtener la reserva por su ID para verificar si existe y si se puede cancelar
            Booking booking = _clientRepository.GetBookingById(bookingId);

            if (booking == null)
                throw new Exception($"Booking with ID {bookingId} does not exist.");

            if (booking.BookingStatus == "Cancelled")
                throw new Exception($"Booking with ID {bookingId} is already cancelled.");

            // Realizar la cancelación de la reserva
            booking.BookingStatus = "Cancelled";
            booking.PaymentStatus = "Refunded";

            return _clientRepository.UpdateBooking(booking);
        }

        public bool CreateBooking(Booking booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking));

            booking.CreatedDate = DateTime.Now;
            booking.BookingStatus = "Active";

            return _clientRepository.CreateBooking(booking);
        }

        public bool DeleteBooking(int bookingId)
        {
            if (bookingId <= 0)
                throw new ArgumentException("Invalid booking ID.");

            Booking booking = _clientRepository.GetBookingById(bookingId);

            if (booking == null)
                throw new Exception($"Booking with ID {bookingId} does not exist.");

            return _clientRepository.DeleteBooking(bookingId);
        }

        public bool DeleteClient(int clientId)
        {
            if (clientId <= 0)
                throw new ArgumentException("Invalid client ID.");

            // Eliminar todas las reservas asociadas al cliente
            List<Booking> bookings = _clientRepository.GetAllBookingsByClientId(clientId);

            foreach (var booking in bookings)
            {
                _clientRepository.DeleteBooking(booking.Id_Booking);
            }

            // Eliminar el cliente
            return _clientRepository.Delete(clientId);
        }

        public List<Booking> GetAllBookingsByClientId(int clientId)
        {
            if (clientId <= 0)
                throw new ArgumentException("Invalid client ID.");

            return _clientRepository.GetAllBookingsByClientId(clientId);
        }

        public List<Flight> GetAvailableFlights()
        {
            return _clientRepository.GetAvailableFlights();
        }

        public Clients GetClientByCredentials(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));

            return _clientRepository.GetClientByCredentials(email, password);
        }

        public Clients GetClientByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));

            return _clientRepository.GetClientByEmail(email);
        }

        public Clients GetClientById(int clientId)
        {
            if (clientId <= 0)
                throw new ArgumentException("Invalid client ID.");

            return _clientRepository.GetClientById(clientId);
        }

        public Flight GetFlightDetails(int flightId)
        {
            if (flightId <= 0)
                throw new ArgumentException("Invalid flight ID.");

            return _clientRepository.GetFlightDetails(flightId);
        }

        public bool Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));

            Clients client = _clientRepository.GetClientByCredentials(email, password);

            if (client != null)
            { 
                return true;
            }

            return false;
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }

        public bool RecoverAccount(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));

            return true;
        }

        public bool UpdateBooking(Booking booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking));

            return _clientRepository.UpdateBooking(booking);
        }

        public bool UpdateClient(Clients client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            return _clientRepository.Update(client);
        }
    }
}