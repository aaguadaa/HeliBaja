﻿using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class ClientRepository : IClientRepository
    {
        public int Add(Client entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Client Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetBookings(int clientId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
