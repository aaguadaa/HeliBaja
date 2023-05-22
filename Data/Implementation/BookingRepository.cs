using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class BookingRepository : IBookingRepository
    {
        public int Add(Booking entity)
        {
            throw new NotImplementedException();
        }

        public bool AddAdminBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAdminBooking(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Booking Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetAdminBookings()
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetBookingsByClient(int Id_Client)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetBookingsByFlight(int Id_Flight)
        {
            throw new NotImplementedException();
        }

        public bool Update(Booking entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAdminBooking(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
