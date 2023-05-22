using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class AgendaRepository : IAgendaRepository
    {

        public bool AddAdminAgenda(Agenda entry)
        {
            throw new NotImplementedException();
        }

        public bool AddFlight(int Id_Agenda, int Id_Flight)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAdminAgenda(int entryId)
        {
            throw new NotImplementedException();
        }

        public Agenda Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Agenda> GetAdminAgenda()
        {
            throw new NotImplementedException();
        }

        public Agenda GetAdminAgendaById(int entryId)
        {
            throw new NotImplementedException();
        }

        public List<Flight> GetFlights(int Id_Agenda)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFlight(int Id_Agenda, int Id_Flight)
        {
            throw new NotImplementedException();
        }

        public bool Update(Agenda entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAdminAgenda(Agenda entry)
        {
            throw new NotImplementedException();
        }
    }
}
