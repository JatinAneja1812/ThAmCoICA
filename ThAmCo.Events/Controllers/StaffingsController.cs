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
    public class StaffingsController : Controller
    {
        private readonly EventContext _context;

        public StaffingsController(EventContext context)
        {
            _context = context;
        }

        // GET: Staffings
        public async Task<IActionResult> Index()
        {
            var eventContext = _context.Staffings.Include(s => s.Event).Include(s => s.Staff);
            return View(await eventContext.ToListAsync());
        }

        // GET: Staffings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffing = await _context.Staffings
                .Include(s => s.Event)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (staffing == null)
            {
                return NotFound();
            }

            return View(staffing);
        }

        // GET: Staffings/Create
        public IActionResult Create(int? id)
        {
            Staffing staff = new Staffing();
            if (id.HasValue)
                staff.EventId = id.Value;
           
            ViewData["EventId"] = new SelectList(_context.Event.Where(x=>x.IsDeleted == false), "EventId", "EventTitle");
            ViewData["StaffId"] = new SelectList(_context.Staff.Where(x=>x.CheckAvailibility == true), "Staffid", "FullName");
            return View(staff);
        }

        // POST: Staffings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,EventId")] Staffing staffing)
        {
            // staffing bind only contains event id and staffid :=> staff == null
            //to change the availibilty of staff on run time
            Staff sft = _context.Staff.Where(x => x.Staffid.Equals(staffing.StaffId)).Single();
            try
            {
                if (staffing.Staff == null)
                {
                    staffing.Staff = sft;
                }
            }catch(NullReferenceException)
            {

            }

            if (ModelState.IsValid)
            {
                staffing.Staff.CheckAvailibility = false;
                _context.Add(staffing);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details","Events", new { id = staffing.EventId });
            }
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventTitle", staffing.EventId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Staffid", "FirstName", staffing.StaffId);
            return View(staffing);
        }

        // GET: Staffings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffing = await _context.Staffings.FindAsync(id);
            if (staffing == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventTitle", staffing.EventId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Staffid", "FirstName", staffing.StaffId);
            return View(staffing);
        }

        // POST: Staffings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffId,EventId")] Staffing staffing)
        {
            if (id != staffing.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffingExists(staffing.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Events", new { id = staffing.EventId });
            }
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventTitle", staffing.EventId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Staffid", "FirstName", staffing.StaffId);
            return View(staffing);
        }

        // GET: Staffings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffing = await _context.Staffings
                .Include(s => s.Event)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staffing == null)
            {
                return NotFound();
            }

            return View(staffing);
        }

        // POST: Staffings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var getstaffid = await _context.Staffings.Where(x => x.StaffId == id).ToListAsync();

            var staffing = await _context.Staffings.FindAsync(getstaffid.FirstOrDefault().EventId,id);
            // staffing bind only contains event id and staffid :=> staff == null
            //to change the availibilty of staff on run time
            Staff sft = _context.Staff.Where(x => x.Staffid.Equals(staffing.StaffId)).Single();
            try
            {
                if (staffing.Staff == null)
                {
                    staffing.Staff = sft;
                }
            }
            catch (NullReferenceException)
            {

            }
            staffing.Staff.CheckAvailibility = true;
            _context.Staffings.Remove(staffing);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details","Events",new { id = staffing.EventId});
        }

        private bool StaffingExists(int id)
        {
            return _context.Staffings.Any(e => e.EventId == id);
        }
    }
}
