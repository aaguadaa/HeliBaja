using Business.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace HeliBaja.Controllers
{
    [RoutePrefix("flight")]
    public class FlightController : ApiController
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetFlightById(int id)
        {
            Flight flight = _flightService.GetFlightById(id);
            if (flight == null)
                return NotFound();

            return Ok(flight);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateFlight([FromBody] Flight flight)
        {
            if (flight == null)
                return BadRequest("Flight data is null.");

            int createdFlightId = _flightService.AddFlight(flight);
            if (createdFlightId <= 0)
                return BadRequest("Unable to create flight.");

            return Ok(new { Id = createdFlightId });
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult UpdateFlight(int id, [FromBody] Flight flight)
        {
            if (flight == null)
                return BadRequest("Flight data is null.");

            flight.Id_Flight = id;
            bool updated = _flightService.UpdateFlight(flight);
            if (!updated)
                return BadRequest("Unable to update flight.");

            return Ok(flight);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteFlight(int id)
        {
            bool deleted = _flightService.DeleteFlight(id);
            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}