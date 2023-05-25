using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IPilotRepository : IGenericRepository<Pilots>
    {
        Pilots GetPilotById(int pilotId);
        IEnumerable<Pilots> GetPilots();
        IEnumerable<Agenda> GetAgendaByPilotId(int pilotId);
    }
}