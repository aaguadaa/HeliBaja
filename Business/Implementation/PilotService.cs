using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;

namespace Business.Implementation
{
    public class PilotService : IPilotService
    {
        private readonly IPilotRepository _pilotRepository;

        public PilotService(IPilotRepository pilotRepository)
        {
            _pilotRepository = pilotRepository;
        }

        public int AddPilot(Pilots pilot)
        {
            return _pilotRepository.Add(pilot);
        }

        public bool DeletePilot(int pilotId)
        {
            return _pilotRepository.Delete(pilotId);
        }

        public IEnumerable<Agenda> GetAgendaByPilotId(int pilotId)
        {
            return _pilotRepository.GetAgendaByPilotId(pilotId);
        }

        public Pilots GetPilotById(int pilotId)
        {
            return _pilotRepository.GetPilotById(pilotId);
        }

        public IEnumerable<Pilots> GetPilots()
        {
            return _pilotRepository.GetPilots();
        }

        public bool UpdatePilot(Pilots pilot)
        {
            return _pilotRepository.Update(pilot);
        }
    }
}