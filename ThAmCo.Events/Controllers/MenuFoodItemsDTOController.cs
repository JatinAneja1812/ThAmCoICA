using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.EventDTOs;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Controllers
{
    public class MenuFoodItemsDTOController : Controller
    {
        private readonly EventContext _context;
        HttpClient client;

        public MenuFoodItemsDTOController(EventContext context)
        {
            _context = context;
            client = new HttpClient();
            client.BaseAddress = new System.Uri("https://localhost:44387/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        // GET: MenuFoodItemsDTO
        public async Task<IActionResult> Index(int id)
        {
            List<MenuFoodItemsDTO> eventfood = new List<MenuFoodItemsDTO>();

            HttpResponseMessage response = await client.GetAsync("api/MenuFoodItems");
            if (response.IsSuccessStatusCode)
            {
                eventfood = await response.Content.ReadAsAsync<List<MenuFoodItemsDTO>>();
            }
            else
            {
                Debug.WriteLine("Index received a bad response from the web service.");
            }

            var eventContext = eventfood.Where(m => m.MenuId == id);
            return View(eventContext);
        }
        private bool MenuFoodItemsDTOExists(int id)
        {
            return _context.MenuFoodItemsDTO.Any(e => e.MenuId == id);
        }
    }
}
