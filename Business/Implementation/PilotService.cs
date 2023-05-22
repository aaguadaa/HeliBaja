using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class PilotService : IPilotService
    {
        private readonly IPilotRepository _pilotRepository;

        public PilotService(IPilotRepository pilotRepository)
        {
            _pilotRepository = pilotRepository;
        }

        public async Task<IEnumerable<Pilots>> GetAllPilots()
        {
            return await _pilotRepository.GetAll();
        }

        public async Task<Pilots> GetPilotById(int pilotId)
        {
            return await _pilotRepository.GetById(pilotId);
        }

        public async Task<int> AddPilot(Pilots pilot)
        {
            return await _pilotRepository.Add(pilot);
        }

        public async Task<bool> UpdatePilot(Pilots pilot)
        {
            return await _pilotRepository.Update(pilot);
        }

        public async Task<bool> DeletePilot(int pilotId)
        {
            return await _pilotRepository.Delete(pilotId);
        }

        public List<Flight> GetFlights(int pilotId)
        {
            return _pilotRepository.GetFlights(pilotId);
        }

        public bool AddFlightToPilot(int flightId, int pilotId)
        {
            return _pilotRepository.AddFlightToPilot(flightId, pilotId);
        }

        public bool RemoveFlightFromPilot(int flightId, int pilotId)
        {
            return _pilotRepository.RemoveFlightFromPilot(flightId, pilotId);
        }
    }
}