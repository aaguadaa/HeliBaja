using Domain.Model;
using System;
using System.Collections.Generic;

namespace Business.Contracts
{
    public interface IInventoryService
    {
        List<Inventory> GetInventoriesByToolName(string toolName);
        bool UpdateInventoryQuantity(int inventoryId, int newQuantity);
        List<Inventory> GetAvailableInventory();
        List<Inventory> GetUnavailableInventory();
        List<Inventory> GetInventoryByTool(string toolName);
        List<Inventory> GetInventoryByDate(DateTime date);
        List<Inventory> GetInventoryByDateRange(DateTime startDate, DateTime endDate);
        int AddInventory(Inventory inventory);
        Inventory GetInventoryById(int inventoryId);
        bool UpdateInventory(Inventory inventory);
        bool DeleteInventory(int inventoryId);
        bool DeleteTool(int toolId);
        bool AddTool(Tools tool);
        Tools GetToolById(int toolId);
        bool UpdateTool(Tools tool);
    }
}