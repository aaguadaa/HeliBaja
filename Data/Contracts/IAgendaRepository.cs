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
        List<Flight> GetFlights(int Id_Agenda);
        bool AddFlight(int Id_Agenda, int Id_Flight);
        bool RemoveFlight(int Id_Agenda, int Id_Flight);
    }
}
