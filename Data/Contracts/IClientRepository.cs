﻿using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IClientRepository : IGenericRepository<Clients>
    {
        List<Booking> GetBookings(int clientId);
    }
}
