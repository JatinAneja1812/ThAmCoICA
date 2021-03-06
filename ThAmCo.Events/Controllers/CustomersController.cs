using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThAmCo.Events.Models;
using ThAmCo.Events.ViewModels;

namespace ThAmCo.Events.Controllers
{
    public class CustomersController : Controller
    {
        private readonly EventContext _context;

        public CustomersController(EventContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            List<Customer> list = await _context.Customers.ToListAsync();
            foreach (Customer item in list)
            {
                if (item.PhoneNumber == "0" || item.PhoneNumber == "" || item.PhoneNumber == null)
                {
                    item.PhoneNumber = "-";
                }// Data Annotation could be either be performed in Customers Model
                // [DisplayFormat(NullDisplayText = "-")]
            }
            return View(list);

        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerDetailsViewModel CustomerDeatils = await _context.Customers
                .Select(m => new CustomerDetailsViewModel
                {
                    // Updating ViewModel
                    CustomerId = m.CustomerId,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    PhoneNumber = m.PhoneNumber,
                    EmailId = m.EmailId
                })
            .FirstOrDefaultAsync(m => m.CustomerId == id);

            if (CustomerDeatils == null)
            {
                return NotFound();
            }
            // updating Guestbooking for the Event in the Customer Detail View.
            var Guestbooking = await _context.GuestBookings.Where(m => m.CustomerId == id).Include(y => y.Events).ToListAsync();
            CustomerDeatils.GuestBookings = Guestbooking;
            return View(CustomerDeatils);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,TelePhoneNumber,EmailId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.PhoneNumber == "0" || customer.PhoneNumber == "" || customer.PhoneNumber == null)
                {
                    customer.PhoneNumber = "-";
                }
                // creating new Customers
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,TelePhoneNumber,EmailId")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            return View(customer);
        }

        // GET: customers/Delete/5
        // Deleting Customers from the root
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custs = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (custs == null)
            {
                return NotFound();
            }

            return View(custs);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var custs = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(custs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
