using Business.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace HeliBaja.Controllers
{
    [RoutePrefix("tools")]
    public class ToolsController : ApiController
    {
        private readonly IToolsService _toolsService;

        public ToolsController(IToolsService toolsService)
        {
            _toolsService = toolsService;
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetToolById(int id)
        {
            Tools tool = _toolsService.GetById(id);
            if (tool == null)
                return NotFound();

            return Ok(tool);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateTool([FromBody] Tools tool)
        {
            if (tool == null)
                return BadRequest("Tool data is null.");

            int createdToolId = _toolsService.Add(tool);
            if (createdToolId <= 0)
                return BadRequest("Unable to create tool.");

            return Ok(new { Id = createdToolId });
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult UpdateTool(int id, [FromBody] Tools tool)
        {
            if (tool == null)
                return BadRequest("Tool data is null.");

            tool.Id = id;
            bool updated = _toolsService.Update(tool);
            if (!updated)
                return BadRequest("Unable to update tool.");

            return Ok(tool);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteTool(int id)
        {
            bool deleted = _toolsService.Delete(id);
            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}