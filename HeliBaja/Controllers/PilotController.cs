using Business.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace HeliBaja.Controllers
{
    [RoutePrefix("pilot")]
    public class PilotController : ApiController
    {
        private readonly IPilotService _pilotService;

        public PilotController(IPilotService pilotService)
        {
            _pilotService = pilotService;
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetPilotById(int id)
        {
            Pilots pilot = _pilotService.GetPilotById(id);
            if (pilot == null)
                return NotFound();

            return Ok(pilot);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult CreatePilot([FromBody] Pilots pilot)
        {
            if (pilot == null)
                return BadRequest("Pilot data is null.");

            int createdPilotId = _pilotService.AddPilot(pilot);
            if (createdPilotId <= 0)
                return BadRequest("Unable to create pilot.");

            return Ok(new { Id = createdPilotId });
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult UpdatePilot(int id, [FromBody] Pilots pilot)
        {
            if (pilot == null)
                return BadRequest("Pilot data is null.");

            pilot.Id_Pilot = id;
            bool updated = _pilotService.UpdatePilot(pilot);
            if (!updated)
                return BadRequest("Unable to update pilot.");

            return Ok(pilot);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeletePilot(int id)
        {
            bool deleted = _pilotService.DeletePilot(id);
            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}