using Domain.Model;
using System.Collections.Generic;

namespace Business.Contracts
{
    public interface IPilotService
    {
        int AddPilot(Pilots pilot);
        bool UpdatePilot(Pilots pilot);
        bool DeletePilot(int pilotId);
        Pilots GetPilotById(int pilotId);
        IEnumerable<Pilots> GetPilots();
        IEnumerable<Agenda> GetAgendaByPilotId(int pilotId);
    }
}