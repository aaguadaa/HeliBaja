using System.Collections.Generic;
using System.Web.Http;
using Domain.Model;
using Business.Contracts;

namespace WebApi.Controllers
{
    public class AdminController : ApiController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IHttpActionResult GetBookings()
        {
            List<Booking> bookings = _adminService.GetBookings();
            return Ok(bookings);
        }

        [HttpPost]
        public IHttpActionResult AddBooking(Booking booking)
        {
            bool isAdded = _adminService.AddBooking(booking);
            if (isAdded)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to add booking.");
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateBooking(Booking booking)
        {
            bool isUpdated = _adminService.UpdateBooking(booking);
            if (isUpdated)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to update booking.");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteBooking(int bookingId)
        {
            bool isDeleted = _adminService.DeleteBooking(bookingId);
            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to delete booking.");
            }
        }

        [HttpGet]
        public IHttpActionResult GetFlights()
        {
            List<Flight> flights = _adminService.GetFlights();
            return Ok(flights);
        }

        [HttpPost]
        public IHttpActionResult AddFlight(Flight flight)
        {
            bool isAdded = _adminService.AddFlight(flight);
            if (isAdded)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to add flight.");
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateFlight(Flight flight)
        {
            bool isUpdated = _adminService.UpdateFlight(flight);
            if (isUpdated)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to update flight.");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteFlight(int flightId)
        {
            bool isDeleted = _adminService.DeleteFlight(flightId);
            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to delete flight.");
            }
        }

        [HttpPost]
        public IHttpActionResult AssignFlightToPilot(int flightId, int pilotId)
        {
            bool isAssigned = _adminService.AssignFlightToPilot(flightId, pilotId);
            if (isAssigned)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to assign flight to pilot.");
            }
        }

        [HttpPost]
        public IHttpActionResult RemoveFlightFromPilot(int flightId, int pilotId)
        {
            bool isRemoved = _adminService.RemoveFlightFromPilot(flightId, pilotId);
            if (isRemoved)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to remove flight from pilot.");
            }
        }
    }
}
