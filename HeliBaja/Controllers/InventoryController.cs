using Business.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace HeliBaja.Controllers
{
    [RoutePrefix("inventory")]
    public class InventoryController : ApiController
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetInventoryById(int id)
        {
            Inventory item = _inventoryService.GetInventoryById(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateItem([FromBody] Inventory item)
        {
            if (item == null)
                return BadRequest("Item data is null.");

            int createdItemId = _inventoryService.AddInventory(item);
            if (createdItemId <= 0)
                return BadRequest("Unable to create item.");

            return Ok(new { Id = createdItemId });
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult UpdateItem(int id, [FromBody] Inventory item)
        {
            if (item == null)
                return BadRequest("Item data is null.");

            item.Id_Inventory = id;
            bool updated = _inventoryService.UpdateInventory(item);
            if (!updated)
                return BadRequest("Unable to update item.");

            return Ok(item);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteItem(int id)
        {
            bool deleted = _inventoryService.DeleteInventory(id);
            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}