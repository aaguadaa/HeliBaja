using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PilotRepository : IPilotRepository
    {
        private readonly HeliBajaDBContext _dbContext;

        public PilotRepository(HeliBajaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {
            var pilot = await _dbContext.Pilots.FindAsync(id);
            if (pilot == null)
            {
                return false;
            }
            _dbContext.Pilots.Remove(pilot);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Pilots> GetById(int id)
        {
            return await _dbContext.Pilots.FindAsync(id);
        }

        public async Task<IEnumerable<Pilots>> GetAll()
        {
            return await _dbContext.Pilots.ToListAsync();
        }

        public async Task<bool> Update(Pilots pilot)
        {
            if (!_dbContext.Pilots.Local.Any(p => p.Id_Pilot == pilot.Id_Pilot))
            {
                _dbContext.Pilots.Attach(pilot);
            }
            _dbContext.Entry(pilot).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public List<Flight> GetFlights(int pilotId)
        {
            var flights = _dbContext.Flights.Where(f => f.PilotId == pilotId).ToList();
            return flights;
        }


        public bool AddFlightToPilot(int flightId, int pilotId)
        {
            var pilot = _dbContext.Pilots.Find(pilotId);
            var flight = _dbContext.Flights.Find(flightId);
            if (pilot == null || flight == null)
            {
                return false;
            }
            pilot.Flights.Add(flight);
            _dbContext.SaveChanges();
            return true;
        }

        public bool RemoveFlightFromPilot(int flightId, int pilotId)
        {
            var pilot = _dbContext.Pilots.Find(pilotId);
            var flight = _dbContext.Flights.Find(flightId);
            if (pilot == null || flight == null)
            {
                return false;
            }
            pilot.Flights.Remove(flight);
            _dbContext.SaveChanges();
            return true;
        }

        int IGenericRepository<Pilots>.Add(Pilots entity)
        {
            throw new NotImplementedException();
        }

        public Pilots Get(int id)
        {
            throw new NotImplementedException();
        }

        bool IGenericRepository<Pilots>.Update(Pilots entity)
        {
            throw new NotImplementedException();
        }

        bool IGenericRepository<Pilots>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
