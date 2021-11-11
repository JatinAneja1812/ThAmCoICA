using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ThAmCo.Events.DTOs;

namespace ThAmCo.Events.Controllers
{
    public class FoodItemsController : Controller
    {
        HttpClient client;
        public FoodItemsController()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("https://localhost:44387/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }
        // GET: FoodItemsController
        public async Task<ActionResult> Index()
        {
            IEnumerable<FoodItemDTO> reviews = new List<FoodItemDTO>();

            HttpResponseMessage response = await client.GetAsync("api/FoodItems");
            if (response.IsSuccessStatusCode)
            {
               reviews = await response.Content.ReadAsAsync<IEnumerable<FoodItemDTO>>();
            }
            else
            {
                Debug.WriteLine("Index received a bad response from the web service.");
            }
            return View(reviews.ToList());
        }



        // GET: FoodItemsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FoodItemsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodItemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodItemsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FoodItemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodItemsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FoodItemsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
