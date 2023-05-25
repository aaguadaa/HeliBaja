using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class FlightRepository : IFlightRepository
    {
        private readonly HeliBajaDBContext _context;

        public FlightRepository(HeliBajaDBContext context)
        {
            _context = context;
        }

        public int Add(Flight entity)
        {
            _context.Flights.Add(entity);
            return _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var flight = _context.Flights.FirstOrDefault(f => f.Id_Flight == id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public Flight Get(int id)
        {
            return _context.Flights.FirstOrDefault(f => f.Id_Flight == id);
        }

        public List<Flight> GetAdminFlights()
        {
            return _context.Flights.Where(f => f.PilotId == 0).ToList();
        }

        public List<Flight> GetAllFlights()
        {
            return _context.Flights.ToList();
        }

        public List<Flight> GetAvailableFlights()
        {
            return _context.Flights.Where(f => !f.Bookings.Any() || f.Status == "Disponible").ToList();
        }

        public List<Flight> GetFlights()
        {
            return _context.Flights.ToList();
        }

        public Task<IEnumerable<Flight>> GetFlightsByBookingId(int bookingId)
        {
            return Task.FromResult<IEnumerable<Flight>>(_context.Flights.Where(f => f.Bookings.Any(b => b.Id_Booking == bookingId)));
        }

        public Task<IEnumerable<Flight>> GetFlightsByDate(DateTime date)
        {
            return Task.FromResult<IEnumerable<Flight>>(_context.Flights.Where(f => f.HoraSalida.Date == date.Date));
        }

        public Task<IEnumerable<Flight>> GetFlightsByDateRange(DateTime startDate, DateTime endDate)
        {
            return Task.FromResult<IEnumerable<Flight>>(_context.Flights.Where(f => f.HoraSalida.Date >= startDate.Date && f.HoraSalida.Date <= endDate.Date));
        }

        public Task<IEnumerable<Flight>> GetFlightsByPilotId(int pilotId)
        {
            return Task.FromResult<IEnumerable<Flight>>(_context.Flights.Where(f => f.PilotId == pilotId));
        }

        public Task<IEnumerable<Flight>> GetFlightsByStatus(string status)
        {
            return Task.FromResult<IEnumerable<Flight>>(_context.Flights.Where(f => f.Status == status));
        }

        public bool Update(Flight entity)
        {
            var existingFlight = _context.Flights.FirstOrDefault(f => f.Id_Flight == entity.Id_Flight);
            if (existingFlight != null)
            {
                existingFlight.NumeroVuelo = entity.NumeroVuelo;
                existingFlight.Origen = entity.Origen;
                existingFlight.Destino = entity.Destino;
                existingFlight.HoraSalida = entity.HoraSalida;
                existingFlight.HoraLlegada = entity.HoraLlegada;
                existingFlight.Bookings = entity.Bookings;
                existingFlight.PilotId = entity.PilotId;
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}