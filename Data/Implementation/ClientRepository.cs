﻿using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly HeliBajaDBContext _dbContext;

        public ClientRepository(HeliBajaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Clients entity)
        {
            _dbContext.Clients.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id_Client;
        }

        public bool Delete(int id)
        {
            var client = _dbContext.Clients.FirstOrDefault(c => c.Id_Client == id);
            if (client == null)
            {
                return false;
            }
            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();
            return true;
        }

        public Clients Get(int id)
        {
            return _dbContext.Clients.FirstOrDefault(c => c.Id_Client == id);
        }

        public IEnumerable<Clients> GetAll()
        {
            return _dbContext.Clients.ToList();
        }

        public bool Update(Clients entity)
        {
            var existingClient = _dbContext.Clients.FirstOrDefault(c => c.Id_Client == entity.Id_Client);
            if (existingClient == null)
            {
                return false;
            }
            existingClient.Name = entity.Name;
            existingClient.APaterno = entity.APaterno;
            existingClient.AMaterno = entity.AMaterno;
            existingClient.Email = entity.Email;
            existingClient.Password = entity.Password;
            _dbContext.SaveChanges();
            return true;
        }

        public List<Booking> GetBookings(int clientId)
        {
            var bookings = _dbContext.Bookings.Where(b => b.Id_Client == clientId).ToList();
            return bookings;
        }
    }
}