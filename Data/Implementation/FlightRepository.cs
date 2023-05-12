using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class FlightRepository : IFlightRepository
    {
        public int Add(Flight entity)
        {
            throw new NotImplementedException();
        }

        public bool AddFlightToPilot(int Id_Flight, int Id_Pilot)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFlight(int Id_Flight)
        {
            throw new NotImplementedException();
        }

        public Flight Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Flight> GetFlights()
        {
            throw new NotImplementedException();
        }

        public bool RemoveFlightFromPilot(int Id_Flight, int Id_Pilot)
        {
            throw new NotImplementedException();
        }

        public bool Update(Flight entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateFlight(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
