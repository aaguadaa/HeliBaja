using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        List<Booking> GetBooking();
        bool AddBooking(Booking booking);
        bool UpdateBooking(Booking booking);
        bool DeleteBooking(int Id_Booking);

        List<Flight> GetFlights();
        bool AddFlight(Flight flight);
        bool UpdateFlight(Flight flight);
        bool DeleteFlight(int Id_Flight);

        bool AddFlightToPilot(int Id_Flight, int Id_Pilot);
        bool RemoveFlightFromPilot(int Id_Flight, int Id_Pilot);
    }
}
