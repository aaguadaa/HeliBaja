using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IInventoryRepository : IGenericRepository<Inventory>
    {
        List<Inventory> GetInventoriesByToolName(string toolName);
        bool UpdateInventoryQuantity(int inventoryId, int newQuantity);
        List<Inventory> GetAvailableInventory();
        List<Inventory> GetUnavailableInventory();
        List<Inventory> GetInventoryByTool(string toolName);
        List<Inventory> GetInventoryByDate(DateTime date);
        List<Inventory> GetInventoryByDateRange(DateTime startDate, DateTime endDate);

        // Métodos CRUD para la entidad "Tools"
        bool AddTool(Tools tool);
        Tools GetToolById(int toolId);
        bool UpdateTool(Tools tool);
        bool DeleteTool(int toolId);
    }
}