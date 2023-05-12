using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class InventoryRepository : IInventoryRepository
    {
        public int Add(Inventory entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Inventory Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetAllInventory()
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetAvailableInventory()
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetInventoriesByToolName(string toolName)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetInventoryByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetInventoryByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetInventoryByTool(string toolName)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetUnavailableInventory()
        {
            throw new NotImplementedException();
        }

        public bool Update(Inventory entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateInventoryQuantity(int inventoryId, int newQuantity)
        {
            throw new NotImplementedException();
        }
    }
}
