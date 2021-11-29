using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Controllers
{
    public class GuestBookingsController : Controller
    {
        private readonly EventContext _context;

        public GuestBookingsController(EventContext context)
        {
            _context = context;
        }

        // GET: GuestBookings
        public async Task<IActionResult> Index()
        {
            var eventContext = _context.GuestBookings.Include(g => g.Custs).Include(g => g.Events);
            return View(await eventContext.ToListAsync());
        }

        // GET: GuestBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestBooking = await _context.GuestBookings
                .Include(g => g.Custs)
                .Include(g => g.Events)
                .FirstOrDefaultAsync(m => m.GuestBookingID == id);
            if (guestBooking == null)
            {
                return NotFound();
            }

            return View(guestBooking);
        }

        // GET: GuestBookings/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "EmailId");
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventTitle");
            return View();
        }

        // POST: GuestBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuestBookingID,CustomerId,EventId,GuestAttendence")] GuestBooking guestBooking)
        {

            if (ModelState.IsValid)
            {
                var isGuestAlreadyExists = _context.GuestBookings.Include(x=>x.Custs).Any(x => x.CustomerId == guestBooking.CustomerId);
                if (isGuestAlreadyExists)
                {
                    ModelState.AddModelError(string.Empty, "User with this Id already exists");
                    ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "EmailId", guestBooking.CustomerId);
                    ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventTitle", guestBooking.EventId);
                    return View(guestBooking);
                }

                _context.Add(guestBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "EmailId", guestBooking.CustomerId);
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventTitle", guestBooking.EventId);
            return View(guestBooking);
        }

        // GET: GuestBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestBooking = await _context.GuestBookings.FindAsync(id);
            if (guestBooking == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "EmailId", guestBooking.CustomerId);
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventTitle", guestBooking.EventId);
            return View(guestBooking);
        }

        // POST: GuestBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuestBookingID,CustomerId,EventId,GuestAttendence")] GuestBooking guestBooking)
        {
            if (id != guestBooking.GuestBookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guestBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestBookingExists(guestBooking.GuestBookingID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "EmailId", guestBooking.CustomerId);
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventTitle", guestBooking.EventId);
            return View(guestBooking);
        }

        // GET: GuestBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestBooking = await _context.GuestBookings
                .Include(g => g.Custs)
                .Include(g => g.Events)
                .FirstOrDefaultAsync(m => m.GuestBookingID == id);
            if (guestBooking == null)
            {
                return NotFound();
            }

            return View(guestBooking);
        }

        // POST: GuestBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guestBooking = await _context.GuestBookings.FindAsync(id);
            _context.GuestBookings.Remove(guestBooking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestBookingExists(int id)
        {
            return _context.GuestBookings.Any(e => e.GuestBookingID == id);
        }
    }
}
