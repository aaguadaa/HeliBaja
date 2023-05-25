using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IFlightRepository _flightRepository;

        public UserService(IUserRepository userRepository, IBookingRepository bookingRepository, IFlightRepository flightRepository)
        {
            _userRepository = userRepository;
            _bookingRepository = bookingRepository;
            _flightRepository = flightRepository;
        }
        public Users GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }
        public List<Users> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public List<Booking> GetUserBookings(int userId)
        {
            return _bookingRepository.GetBookingsByClientId(userId).ToList();
        }
        public List<Flight> GetAvailableFlights()
        {
            return _flightRepository.GetFlights().Where(flight => flight.Status == "Available").ToList();
        }
        public bool BookFlight(int userId, int flightId)
        {
            Flight flight = _flightRepository.GetFlightsByBookingId(flightId).Result.FirstOrDefault();
            if (flight == null || flight.Status != "Available")
                return false;

            Booking booking = new Booking
            {
                Id_Client = userId,
                Id_Flight = flightId,
                CreatedDate = DateTime.Now,
                TourDate = flight.HoraSalida,
                PaymentMethod = "Payment Method",
                PaymentStatus = "Pending",
                BookingStatus = "Active"
            };

            _bookingRepository.Add(booking);

            flight.Status = "Booked";
            _flightRepository.Update(flight);

            return true;
        }
        public bool CancelBooking(int bookingId)
        {
            Booking booking = _bookingRepository.GetBookingsByFlightId(bookingId).FirstOrDefault();
            if (booking == null)
                return false;

            if (booking.BookingStatus == "Cancelled")
                return false;

            booking.BookingStatus = "Cancelled";
            _bookingRepository.Update(booking);

            Flight flight = _flightRepository.GetFlightsByBookingId(booking.Id_Flight).Result.FirstOrDefault();
            if (flight != null)
            {
                flight.Status = "Available";
                _flightRepository.Update(flight);
            }

            return true;
        }
        public List<Users> GetAdminUsers()
        {
            return _userRepository.GetAdminUsers();
        }
        public Users GetAdminUserById(int userId)
        {
            return _userRepository.GetAdminUserById(userId);
        }
        public bool AddAdminUser(Users user)
        {
            if (user == null || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
                return false;

            user.IsAdmin = true;
            _userRepository.Add(user);
            return true;
        }
        public bool UpdateAdminUser(Users user)
        {
            Users existingUser = _userRepository.GetAdminUserById(user.Id);
            if (existingUser == null)
                return false;

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            _userRepository.Update(existingUser);
            return true;
        }
        public bool DeleteAdminUser(int userId)
        {
            Users existingUser = _userRepository.GetAdminUserById(userId);
            if (existingUser == null || !existingUser.IsAdmin)
                return false;

            _userRepository.Delete(userId);
            return true;
        }
        public bool AssignUserType(int userId, UserType userType)
        {
            Users existingUser = _userRepository.GetAdminUserById(userId);
            if (existingUser == null || !existingUser.IsAdmin)
                return false;

            existingUser.UserType = userType;
            _userRepository.Update(existingUser);
            return true;
        }
    }
}
