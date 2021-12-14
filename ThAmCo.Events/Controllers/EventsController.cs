using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
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

                var eventIndexViewModel = evtcts
                .Join(evtTps, et => et.EventTypeId, ec => ec.Id,
                (evtcts, evtTps) => new EventIndexViewModel
                {
                    EventId = evtcts.EventId,
                    EventTitle = evtcts.EventTitle,
                    EventDateTime = evtcts.EventDateTime,
                    EventTypeTitle = evtTps.Title,  
                    EventTypeId = evtTps.Id
                });
                
                return View(eventIndexViewModel);
            }
            else
            {
                return BadRequest("Data did not found");
            }
        }

        // GET: EventController
        public ActionResult BookGuests()
        {
            return View();
        }


        [HttpPost]
        public ActionResult BookGuests(string emailId)
        {
            var getcustomerList = _context.Customers.ToList();
            ViewBag.data = getcustomerList;
            ViewData["Email"] = new SelectList(ViewBag.data, "CustomerId", "EmailId",emailId.ToString());
            foreach (Customer C in getcustomerList)
            {
                if(C.EmailId == emailId)
                {
                    return RedirectToAction("Create","GuestBookings");
                }
                else
                { 
                    var msg = MessageBox.Show("This Guest Id Doesn't exists in our Guest list! Would you like to create New", "Guest Not Found??", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (msg == MessageBoxResult.Cancel)
                    {
                        return View();
                        
                    }
                    return RedirectToAction("Create", "Customers");
                }
            }
            return View();
                
        }

        // GET: EventController
        public async Task<ActionResult> BookVenues(string EventTypesid, DateTime begindate)
        {
            List<VenueDTO> venues = new List<VenueDTO>();
            EventVenueAvailibilityCheckModel m = new EventVenueAvailibilityCheckModel();
            m.EventTypeId = EventTypesid;
            m.Getdate = begindate;

            string[] format = {"s"};

            for (int i = 0; i < format.Length; i++)
            {
                m.BeginDate = m.Getdate.ToString(format[i], DateTimeFormatInfo.InvariantInfo);
            }
            for (int j = 0; j < format.Length; j++)
            {
                m.EndDate = m.Getdate.AddDays(1).ToString(format[j], DateTimeFormatInfo.InvariantInfo);

            }
            
            HttpResponseMessage response = await client.GetAsync("api/Availability?eventType="+ m.EventTypeId+ "&beginDate="+ m.BeginDate+ "&endDate="+ m.EndDate);
            if (response.IsSuccessStatusCode)
            {
                venues = await response.Content.ReadAsAsync<List<VenueDTO>>(); 
            }
            
            return View(venues.ToList());
        }

        // GET: EventController
        public async Task<ActionResult> ReserveVenue(VenueDTO rp)
        {
            ReservationPostDTO newResv = new ReservationPostDTO();
            
            newResv.VenueCode = rp.Code;
            newResv.EventDate = rp.Date.Date;
            newResv.allstaffs = await _context.Staff.Where(s => s.StaffType == "Manager").ToListAsync();
            ViewData["staff"] = new SelectList(newResv.allstaffs, "Staffid", "FullName");
            newResv.StaffId = newResv.allstaffs.FirstOrDefault().Staffid.ToString();
            return View(newResv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReserveVenue([Bind("VenueCode,StaffId,EventDate")] ReservationPostDTO rp)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var datestr = rp.EventDate.ToString("yyyy-MM-dd");
                    List<ReservationDTO> reservations = new List<ReservationDTO>();
                    StringContent contents = new StringContent(JsonConvert.SerializeObject(rp), Encoding.UTF8, "application/json");
                    // HTTP POST
                    HttpResponseMessage response = await client.PostAsync("api/Reservations", contents);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        string Json = await response.Content.ReadAsStringAsync();
                        ReservationDTO records = JsonConvert.DeserializeObject<ReservationDTO>(Json);   // converting Json string to ReservationDTO object
                        HttpResponseMessage responsetoReserve = await client.GetAsync("api/Reservations");
                        
                        
                    }
                }
                catch (NullReferenceException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EventDetailsViewModel eventsdetails = await _context.Event
                .Select(m => new EventDetailsViewModel
                {
                     EventId = m.EventId,
                     EventTitle = m.EventTitle,
                     EventDateTime = m.EventDateTime,
                     EventTypeId = m.EventTypeId
                })
            .FirstOrDefaultAsync(m => m.EventId == id);
            
            if (eventsdetails == null)
            {
                return NotFound();
            }
            
            var Guestbooking = await _context.GuestBookings.Where(m=>m.EventId == id).Include(y=>y.Custs).ToListAsync();
            eventsdetails.GuestBookings = Guestbooking;
            // returning appropriate guest list
            eventsdetails.TotalGuestCount = Guestbooking.Count(); // returning count

            // returning appropriate staffs list    // 
            var staffs = await _context.Staffings.Where(m => m.EventId == id).Include(s=>s.Staff).Where(x => x.Staff.CheckAvailibility == false).ToListAsync();
            eventsdetails.Staffings = staffs;
            if (eventsdetails.Staffings.Any(m=>m.Staff.isFirstAider == true))
            {
                ModelState.AddModelError(string.Empty, " First-Aider Staff is assigned to this Event!!");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "No First-Aider Staff is assigned to this Event!!");
            }

            //check whether first aider  is exists in the event or not


            return View(eventsdetails);
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
            List<EventTypeDTO> evttps = new List<EventTypeDTO>();

            HttpResponseMessage response = await client.GetAsync("api/eventtypes");
            //EventTitleViewModel employeeDeatailsViewModel;

            if (response.IsSuccessStatusCode)
            {
                evttps = await response.Content.ReadAsAsync<List<EventTypeDTO>>();
                ViewData["EventType"] = new SelectList(evttps, "Id", "Title", @event.EventTypeId);
      
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EventTitle,EventDateTime,EventTypeId ")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(@event).State = EntityState.Modified;
                    _context.Entry(@event).Property("EventDateTime").IsModified = false;
                    //_context.Update(@event);
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
