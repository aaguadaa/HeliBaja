using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IPilotRepository : IGenericRepository<Pilot>
    {
        List<Flight> GetFlights(int pilotId);
        bool AddFlightToPilot(int flightId, int pilotId);
        bool RemoveFlightFromPilot(int flightId, int pilotId);
    }
}
