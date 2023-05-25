using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;

namespace Business.Implementation
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public List<Inventory> GetInventoriesByToolName(string toolName)
        {
            return _inventoryRepository.GetInventoriesByToolName(toolName);
        }

        public bool UpdateInventoryQuantity(int inventoryId, int newQuantity)
        {
            return _inventoryRepository.UpdateInventoryQuantity(inventoryId, newQuantity);
        }

        public List<Inventory> GetAvailableInventory()
        {
            return _inventoryRepository.GetAvailableInventory();
        }

        public List<Inventory> GetUnavailableInventory()
        {
            return _inventoryRepository.GetUnavailableInventory();
        }

        public List<Inventory> GetInventoryByTool(string toolName)
        {
            return _inventoryRepository.GetInventoryByTool(toolName);
        }

        public List<Inventory> GetInventoryByDate(DateTime date)
        {
            return _inventoryRepository.GetInventoryByDate(date);
        }

        public List<Inventory> GetInventoryByDateRange(DateTime startDate, DateTime endDate)
        {
            return _inventoryRepository.GetInventoryByDateRange(startDate, endDate);
        }

        public bool AddTool(Tools tool)
        {
            return _inventoryRepository.AddTool(tool);
        }

        public Tools GetToolById(int toolId)
        {
            return _inventoryRepository.GetToolById(toolId);
        }

        public bool UpdateTool(Tools tool)
        {
            return _inventoryRepository.UpdateTool(tool);
        }

        public int AddInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public Inventory GetInventoryById(int inventoryId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public bool DeleteInventory(int inventoryId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTool(int toolId)
        {
            throw new NotImplementedException();
        }
    }
}