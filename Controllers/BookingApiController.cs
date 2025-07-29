using HerveyPlayersBooking.Data;
using HerveyPlayersBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HerveyPlayersBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingApiController : ControllerBase
    {
        private readonly BookingContext _context;

        public BookingApiController(BookingContext context)
        {
            _context = context;
        }

        // =======================
        // GET: api/BookingApi
        // =======================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        // =======================
        // GET: api/BookingApi/5
        // =======================
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
                return NotFound();

            return booking;
        }

        // =======================
        // POST: api/BookingApi
        // =======================
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
        }

        // =======================
        // PUT: api/BookingApi/5
        // =======================
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.Id)
                return BadRequest();

            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // =======================
        // DELETE: api/BookingApi/5
        // =======================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
                return NotFound();

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // =======================
        // STRIPE PAYMENT PLACEHOLDER
        // =======================
        // Future endpoint: initiate payment session
        [HttpPost("start-payment")]
        public IActionResult StartPayment([FromBody] int bookingId)
        {
            // Placeholder: in future this will call Stripe API
            return Ok(new { message = "Stripe payment integration coming soon", bookingId });
        }
    }
}
