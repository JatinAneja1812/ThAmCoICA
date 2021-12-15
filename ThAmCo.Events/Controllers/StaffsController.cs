using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Models;
using ThAmCo.Events.ViewModels;

namespace ThAmCo.Events.Controllers
{
    public class StaffsController : Controller
    {
        private readonly EventContext _context;

        public StaffsController(EventContext context)
        {
            _context = context;
        }

        // GET: Staffs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Staff.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            StaffDetailsViewModel staffdetails = await _context.Staff
                .Select(m => new StaffDetailsViewModel
                {
                     Staffid = m.Staffid,
                     FirstName = m.FirstName,
                     LastName = m.LastName,
                     StaffType = m.StaffType,
                     CheckAvailibility = m.CheckAvailibility,
                     isFirstAider = m.isFirstAider
                })
            .FirstOrDefaultAsync(m => m.Staffid == id);

            if (staffdetails == null)
            {
                return NotFound();
            }

            var staffings = await _context.Staffings.Where(m => m.StaffId == id).Include(s=>s.Event).Include(s=>s.Staff).ToListAsync();
            staffdetails.staffings = staffings;
            // returning appropriate guest list
            
            return View(staffdetails);
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            Staff s = new Staff();
            s.CheckAvailibility = true;
            return View(s);
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Staffid,FirstName,LastName,StaffType,CheckAvailibility,isFirstAider")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Staffid,FirstName,LastName,StaffType,CheckAvailibility")] Staff staff)
        {
            if (id != staff.Staffid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.Staffid))
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
            return View(staff);
        }
        private bool StaffExists(int id)
        {
            return _context.Staff.Any(e => e.Staffid == id);
        }
    }
}
