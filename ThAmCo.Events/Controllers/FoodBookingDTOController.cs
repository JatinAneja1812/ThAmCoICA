using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ThAmCo.Events.EventDTOs;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Controllers
{
    public class FoodBookingDTOController : Controller
    {
        private readonly EventContext _context;
        HttpClient client;
        public FoodBookingDTOController(EventContext context)
        {
            _context = context;
            client = new HttpClient();
            client.BaseAddress = new System.Uri("https://localhost:44387/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        // GET: FoodBookingDTO
        public async Task<IActionResult> Index()
        {
            List<FoodBookingDTO> eventfood = new List<FoodBookingDTO>();

            HttpResponseMessage response = await client.GetAsync("api/FoodBookings");
            if (response.IsSuccessStatusCode)
            {
                eventfood = await response.Content.ReadAsAsync<List<FoodBookingDTO>>();
            }
            else
            {
                Debug.WriteLine("Index received a bad response from the web service.");
            }
           
            return View(eventfood);
        }

        // GET: FoodBookingDTO/Create
        public async Task<IActionResult> Create(int ClientReferenceId, int NumofGuests)

        {
            List<MenusDTO> eventmenu = new List<MenusDTO>();
            FoodBookingDTO fb = new FoodBookingDTO();
            fb.ClientReferenceId = ClientReferenceId;
            fb.NumberOfGuests = NumofGuests;
            HttpResponseMessage response = await client.GetAsync("api/Menus");
            if (response.IsSuccessStatusCode)
            {
                eventmenu = await response.Content.ReadAsAsync<List<MenusDTO>>();
            }
            else
            {
                Debug.WriteLine("Index received a bad response from the web service.");
            }
            ViewData["MenuId"] = new SelectList(eventmenu, "MenuId", "MenuName");
            return View(fb);
        }

        // POST: FoodBookingDTO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodBookingId,ClientReferenceId,NumberOfGuests,MenuId")] FoodBookingDTO foodBookingDTO)
        {
            List<FoodBookingDTO> newbooking = new List<FoodBookingDTO>();
            //StringContent contents = new StringContent(JsonConvert.SerializeObject(foodBookingDTO), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsJsonAsync("api/FoodBookings", foodBookingDTO);
            
            if (response.IsSuccessStatusCode)
            {
                HttpResponseMessage responseget = await client.GetAsync("api/FoodBookings");
                newbooking = await responseget.Content.ReadAsAsync<List<FoodBookingDTO>>();

                // finding Key ReservationId to update with Reference of reservation
                var @event = await _context.Event.FindAsync(foodBookingDTO.ClientReferenceId);
                @event.FoodBookingId = newbooking.Where(m=>m.ClientReferenceId == @event.EventId).FirstOrDefault().FoodBookingId;
                _context.Update(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Events");
            }
            else
            {
                Debug.WriteLine("Create received a bad response from the web service.");
            }
            return View(foodBookingDTO);
        }

        // GET: FoodBookingDTO/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<FoodBookingDTO> eventFoodBooking= new List<FoodBookingDTO>();
            List<MenusDTO> eventmenu = new List<MenusDTO>();
            List<FoodBookingDTO> eventmenufind = new List<FoodBookingDTO>();
            FoodBookingDTO fb = new FoodBookingDTO();

            HttpResponseMessage response = await client.GetAsync("api/FoodBookings");   // return already food booking 
            HttpResponseMessage responseMenu = await client.GetAsync("api/Menus"); // return all the menus available

            if (responseMenu.IsSuccessStatusCode)
            {
                eventmenu = await responseMenu.Content.ReadAsAsync<List<MenusDTO>>();
            }
            if (response.IsSuccessStatusCode)
            {
                // population FoodBookingDTO
                eventFoodBooking = await response.Content.ReadAsAsync<List<FoodBookingDTO>>();
                eventmenufind = eventFoodBooking.Where(m => m.FoodBookingId == id).ToList();
                fb.ClientReferenceId = eventmenufind.FirstOrDefault().ClientReferenceId;
                fb.NumberOfGuests = eventmenufind.FirstOrDefault().NumberOfGuests;
                fb.MenuId = eventmenufind.FirstOrDefault().MenuId;
                fb.Menu = eventmenufind.FirstOrDefault().Menu;
                fb.FoodBookingId = eventmenufind.FirstOrDefault().FoodBookingId;
            }
            else
            {
                Debug.WriteLine("Index received a bad response from the web service.");
            }
            ViewData["MenuId"] = new SelectList(eventmenu, "MenuId", "MenuName", eventmenufind.FirstOrDefault().MenuId);
            return View(fb);
        }

        // POST: FoodBookingDTO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodBookingId,ClientReferenceId,NumberOfGuests,MenuId")] FoodBookingDTO foodBookingDTO)
        {
            if (id != foodBookingDTO.FoodBookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   // List<FoodBookingDTO> alteredMenu = new List<FoodBookingDTO>();
                    FoodBookingDTO records = new FoodBookingDTO();
                    //StringContent contents = new StringContent(JsonConvert.SerializeObject(foodBookingDTO), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsJsonAsync("api/FoodBookings/"+ id, foodBookingDTO);

                    if (response.IsSuccessStatusCode)
                    {
                        HttpResponseMessage responseget = await client.GetAsync("api/FoodBookings/"+id);
                        if (responseget.IsSuccessStatusCode)
                        {
                            string Json = await responseget.Content.ReadAsStringAsync();
                            records = JsonConvert.DeserializeObject<FoodBookingDTO>(Json);
                        }
                        
                    }
                    return RedirectToAction("Details", "Events", new { id =  records.ClientReferenceId });
                }
                catch (NullReferenceException)
                {
                    
                }
            }
            ViewData["MenuId"] = new SelectList(_context.Set<MenusDTO>(), "MenuId", "MenuName", foodBookingDTO.MenuId);
            return View(foodBookingDTO);
        }

        // GET: FoodBookingDTO/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            List<FoodBookingDTO> eventFoodBooking = new List<FoodBookingDTO>();
            List<FoodBookingDTO> eventmenufind = new List<FoodBookingDTO>();
            FoodBookingDTO fb = new FoodBookingDTO();

            HttpResponseMessage response = await client.GetAsync("api/FoodBookings");   // return already food booking 
          
            if (response.IsSuccessStatusCode)
            {
                // population FoodBookingDTO
                eventFoodBooking = await response.Content.ReadAsAsync<List<FoodBookingDTO>>();
                eventmenufind = eventFoodBooking.Where(m => m.FoodBookingId == id).ToList();
                fb.ClientReferenceId = eventmenufind.FirstOrDefault().ClientReferenceId;
                fb.NumberOfGuests = eventmenufind.FirstOrDefault().NumberOfGuests;
                fb.MenuId = eventmenufind.FirstOrDefault().MenuId;
                fb.Menu = eventmenufind.FirstOrDefault().Menu;
                fb.FoodBookingId = eventmenufind.FirstOrDefault().FoodBookingId;
            }
            else
            {
                Debug.WriteLine("Index received a bad response from the web service.");
            }

            return View(fb);
        }

        // POST: FoodBookingDTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            List<Event> @event = await _context.Event.Where(m=>m.FoodBookingId == id).ToListAsync(); // since there is only one foodbooking id for  aparticular event
            var events = await _context.Event.FindAsync(@event.FirstOrDefault().EventId); // this will sort the event out and give me a particular vent
            events.FoodBookingId = null; // on delete Foodbooking for an event turns null
            try
            {
                _context.Update(events);
                await _context.SaveChangesAsync();
            }
            catch (NullReferenceException)
            {

            }
            
            HttpResponseMessage responsedelete = await client.DeleteAsync("api/FoodBookings/"+id);   // return already food booking 
            if (responsedelete.IsSuccessStatusCode)
            {
                RedirectToAction("Index", "Events");
            }

            return BadRequest("This Menu cannot be Deleted due to Server Error!!");
        }

        private bool FoodBookingDTOExists(int id)
        {
            return _context.FoodBookingDTO.Any(e => e.FoodBookingId == id);
        }
    }
}
