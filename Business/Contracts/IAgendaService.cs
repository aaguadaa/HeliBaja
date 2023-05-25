using Domain.Model;
using System.Collections.Generic;

namespace Business.Contracts
{
    public interface IAgendaService
    {
        int AddAgenda(Agenda agenda);
        bool UpdateAgenda(Agenda agenda);
        bool DeleteAgenda(int agendaId);
        Agenda GetAgendaById(int agendaId);
        IEnumerable<Agenda> GetAllAgendas();
        IEnumerable<Agenda> GetAgendasByPilotId(int pilotId);
        IEnumerable<Agenda> GetAgendasByFlightId(int flightId);
    }
}