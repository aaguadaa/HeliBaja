using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;

namespace Business.Implementation
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaService(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public int AddAgenda(Agenda agenda)
        {
            return _agendaRepository.Add(agenda);
        }

        public bool UpdateAgenda(Agenda agenda)
        {
            return _agendaRepository.Update(agenda);
        }

        public bool DeleteAgenda(int agendaId)
        {
            return _agendaRepository.Delete(agendaId);
        }

        public Agenda GetAgendaById(int agendaId)
        {
            return _agendaRepository.Get(agendaId);
        }

        public IEnumerable<Agenda> GetAgendasByFlightId(int flightId)
        {
            return _agendaRepository.GetAgendasByFlightId(flightId);
        }

        public IEnumerable<Agenda> GetAgendasByPilotId(int pilotId)
        {
            return _agendaRepository.GetAgendasByPilotId(pilotId);
        }

        public IEnumerable<Agenda> GetAllAgendas()
        {
            return _agendaRepository.GetAll();
        }
    }
}