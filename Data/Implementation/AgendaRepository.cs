using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly HeliBajaDBContext _dbContext;

        public AgendaRepository(HeliBajaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Agenda agenda)
        {
            _dbContext.Agendas.Add(agenda);
            _dbContext.SaveChanges();
            return agenda.Id_Agenda;
        }

        public bool Update(Agenda agenda)
        {
            var existingAgenda = _dbContext.Agendas.FirstOrDefault(a => a.Id_Agenda == agenda.Id_Agenda);
            if (existingAgenda == null)
                return false;

            existingAgenda.Id_Pilot = agenda.Id_Pilot;
            existingAgenda.Id_Flight = agenda.Id_Flight;
            existingAgenda.Date = agenda.Date;
            existingAgenda.Itinerary = agenda.Itinerary;

            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int agendaId)
        {
            var agenda = _dbContext.Agendas.FirstOrDefault(a => a.Id_Agenda == agendaId);
            if (agenda == null)
                return false;

            _dbContext.Agendas.Remove(agenda);
            _dbContext.SaveChanges();
            return true;
        }

        public Agenda Get(int agendaId)
        {
            return _dbContext.Agendas.FirstOrDefault(a => a.Id_Agenda == agendaId);
        }

        public IEnumerable<Agenda> GetAll()
        {
            return _dbContext.Agendas.ToList();
        }

        public IEnumerable<Agenda> GetAgendasByPilotId(int pilotId)
        {
            return _dbContext.Agendas.Where(a => a.Id_Pilot == pilotId).ToList();
        }

        public IEnumerable<Agenda> GetAgendasByFlightId(int flightId)
        {
            return _dbContext.Agendas.Where(a => a.Id_Flight == flightId).ToList();
        }
    }
}