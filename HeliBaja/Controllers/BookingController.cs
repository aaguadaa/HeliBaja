using Business.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace HeliBaja.Controllers
{
    [RoutePrefix("booking")]
    public class BookingController : ApiController
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllBookings()
        {
            IEnumerable<Booking> bookings = _bookingService.GetAllBookings();
            List<Booking> bookingList = new List<Booking>(bookings);
            return Ok(bookingList);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetBookingById(int id)
        {
            Booking booking = _bookingService.GetBookingById(id);
            if (booking == null)
                return NotFound();

            return Ok(booking);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateBooking([FromBody] Booking booking)
        {
            if (booking == null)
                return BadRequest("Booking data is null.");

            int createdBookingId = _bookingService.AddBooking(booking);
            if (createdBookingId <= 0)
                return BadRequest("Unable to create booking.");

            return Ok(new { Id = createdBookingId });
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult UpdateBooking(int id, [FromBody] Booking booking)
        {
            if (booking == null)
                return BadRequest("Booking data is null.");

            booking.Id_Booking = id;
            bool updated = _bookingService.UpdateBooking(booking);
            if (!updated)
                return BadRequest("Unable to update booking.");

            return Ok(booking);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteBooking(int id)
        {
            bool deleted = _bookingService.DeleteBooking(id);
            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}