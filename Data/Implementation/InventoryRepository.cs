using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace Data.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly HeliBajaDBContext _dbContext;

        public InventoryRepository(HeliBajaDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Inventory> GetInventoriesByToolName(string toolName)
        {
            return _dbContext.Inventories.Where(i => i.Name == toolName).ToList();
        }
        public bool UpdateInventoryQuantity(int inventoryId, int newQuantity)
        {
            var inventory = _dbContext.Inventories.Find(inventoryId);
            if (inventory == null)
            {
                return false;
            }
            inventory.Amount = newQuantity;
            _dbContext.SaveChanges();
            return true;
        }
        public List<Inventory> GetAvailableInventory()
        {
            return _dbContext.Inventories.Where(i => i.Available).ToList();
        }

        public List<Inventory> GetUnavailableInventory()
        {
            return _dbContext.Inventories.Where(i => !i.Available).ToList();
        }
        public List<Inventory> GetInventoryByTool(string toolName)
        {
            return _dbContext.Inventories.Where(i => i.Name.Contains(toolName)).ToList();
        }
        public List<Inventory> GetInventoryByDate(DateTime date)
        {
            return _dbContext.Inventories.Where(i => DbFunctions.TruncateTime(i.Date) == DbFunctions.TruncateTime(date)).ToList();
        }
        public List<Inventory> GetInventoryByDateRange(DateTime startDate, DateTime endDate)
        {
            return _dbContext.Inventories.Where(i => i.Date >= startDate && i.Date <= endDate).ToList();
        }
        public int Add(Inventory entity)
        {
            _dbContext.Inventories.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id_Inventory;
        }
        public Inventory Get(int id)
        {
            return _dbContext.Inventories.FirstOrDefault(i => i.Id_Inventory == id);
        }
        public bool Update(Inventory entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var inventory = _dbContext.Inventories.FirstOrDefault(i => i.Id_Inventory == id);
            if (inventory != null)
            {
                _dbContext.Inventories.Remove(inventory);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteTool(int toolId)
        {
            var tool = _dbContext.tools.Find(toolId);
            if (tool == null)
                return false;

            _dbContext.tools.Remove(tool);
            _dbContext.SaveChanges();
            return true;
        }

        public bool AddTool(Tools tool)
        {
            _dbContext.tools.Add(tool);
            _dbContext.SaveChanges();
            return true;
        }

        public Tools GetToolById(int toolId)
        {
            return _dbContext.tools.FirstOrDefault(t => t.Id == toolId);
        }

        public bool UpdateTool(Tools tool)
        {
            var existingTool = _dbContext.tools.Find(tool.Id);
            if (existingTool == null)
                return false;

            // Actualizar las propiedades del tool existente con los valores del tool pasado como argumento
            existingTool.Name = tool.Name;
            existingTool.Quantity = tool.Quantity;
            existingTool.Description = tool.Description;

            _dbContext.SaveChanges();
            return true;
        }
    }
}