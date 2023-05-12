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
        List<Booking> GetBookingsByClient(int Id_Client);
        List<Booking> GetBookingsByFlight(int Id_Flight);
    }
}
