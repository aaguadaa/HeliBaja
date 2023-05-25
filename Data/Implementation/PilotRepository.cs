using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repositories
{
    public class PilotRepository : IPilotRepository
    {
        private readonly HeliBajaDBContext _dbContext;

        public PilotRepository(HeliBajaDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Pilots pilot)
        {
            _dbContext.Pilots.Add(pilot);
            _dbContext.SaveChanges();
            return pilot.Id_Pilot;
        }
        public bool Update(Pilots pilot)
        {
            _dbContext.Entry(pilot).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
        public bool Delete(int pilotId)
        {
            var pilot = _dbContext.Pilots.FirstOrDefault(p => p.Id_Pilot == pilotId);
            if (pilot != null)
            {
                _dbContext.Pilots.Remove(pilot);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public Pilots GetPilotById(int pilotId)
        {
            return _dbContext.Pilots.FirstOrDefault(p => p.Id_Pilot == pilotId);
        }
        public IEnumerable<Pilots> GetPilots()
        {
            return _dbContext.Pilots.ToList();
        }
        public IEnumerable<Agenda> GetAgendaByPilotId(int pilotId)
        {
            return _dbContext.Agendas.Where(a => a.Id_Pilot == pilotId).ToList();
        }
        public Pilots Get(int id)
        {
            return _dbContext.Pilots.FirstOrDefault(p => p.Id_Pilot == id);
        }
    }
}