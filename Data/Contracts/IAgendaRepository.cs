using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IAgendaRepository : IGenericRepository<Agenda>
    {
        IEnumerable<Agenda> GetAll();
        IEnumerable<Agenda> GetAgendasByPilotId(int pilotId);
        IEnumerable<Agenda> GetAgendasByFlightId(int flightId);
    }
}
