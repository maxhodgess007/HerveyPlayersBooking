using HerveyPlayersBooking.Data;
using HerveyPlayersBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace HerveyPlayersBooking.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingContext _context;

        public BookingController(BookingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.PaymentConfirmed = false;
                _context.Bookings.Add(booking);
                _context.SaveChanges();

                return RedirectToAction("Confirm");
            }

            return View(booking);
        }

        public IActionResult Confirm()
        {
            return View();
        }
    }
}