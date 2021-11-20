using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ThAmCo.Events.EventDTOs;
using ThAmCo.Events.Models;
using ThAmCo.Events.ViewModels;

namespace ThAmCo.Events.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventContext _context;

        HttpClient client;
        public EventsController(EventContext context)
        {
            _context = context;
            client = new HttpClient();
            client.BaseAddress = new System.Uri("https://localhost:44352/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        // GET: EventTypeDTOController
        public async Task<ActionResult> Index()
        {
            List<EventTypeDTO> evtTps = new List<EventTypeDTO>();

            HttpResponseMessage response = await client.GetAsync("api/eventtypes");
            //EventDetailsViewModel eventDetailViewModel;
            if (response.IsSuccessStatusCode)
            {
                evtTps = await response.Content.ReadAsAsync<List<EventTypeDTO>>();
                var evtcts = await _context.Event.ToListAsync();

                var eventDetailViewModel = evtcts
                .Join(evtTps, et => et.EventTypeId, ec => ec.Id,
                (evtcts, evtTps) => new EventDetailsViewModel
                {
                    EventId = evtcts.EventId,
                    EventTitle = evtcts.EventTitle,
                    EventDateTime = evtcts.EventDateTime,
                    EventTypeTitle = evtTps.Title
                });
                return View(eventDetailViewModel);
            }
            else
            {
                return BadRequest("Data didnot found");
            }
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public async Task<IActionResult> Create()
        {
            List<EventTypeDTO> evttps = new List<EventTypeDTO>();

            HttpResponseMessage response = await client.GetAsync("api/eventtypes");
            //EventTitleViewModel employeeDeatailsViewModel;

            if (response.IsSuccessStatusCode)
            {
                evttps = await response.Content.ReadAsAsync<List<EventTypeDTO>>();
                ViewBag.data = evttps;
                ViewData["EventType"] = new SelectList(ViewBag.data, "Id", "Title");
            }

            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,EventTitle,EventTypeId,EventDateTime")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EventDateTime,EventTitle")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
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
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventId == id);
        }
    }
}
