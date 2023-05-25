using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        IEnumerable<Booking> GetBookingsByClientId(int clientId);
        IEnumerable<Booking> GetBookingsByFlightId(int flightId);
        IEnumerable<Booking> GetAllBookings();
    }
}