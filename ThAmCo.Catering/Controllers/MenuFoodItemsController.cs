using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Catering.DataModels;

namespace ThAmCo.Catering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuFoodItemsController : ControllerBase
    {
        private readonly ThAmCo_CateringDBContext _context;

        public MenuFoodItemsController(ThAmCo_CateringDBContext context)
        {
            _context = context;
        }


        // GET:api/MenuFoodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuFoodItem>>> GetFoodItems()
        {
            return await _context.MenuFoodItems.ToListAsync();
        }

        // POST: api/MenuFoodItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MenuFoodItem>> PostMenuFoodItem(MenuFoodItem menuFoodItem)
        {
            _context.MenuFoodItems.Add(menuFoodItem);
            await _context.SaveChangesAsync();
        
            return CreatedAtAction("GetMenuFoodItem", new { id = menuFoodItem.MenuId });
        }

        // DELETE: api/MenuFoodItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuFoodItem>> DeleteMenuFoodItem(int id)
        {
            var menuFoodItem = await _context.MenuFoodItems.FindAsync(id);
            if (menuFoodItem == null)
            {
                return NotFound();
            }

            _context.MenuFoodItems.Remove(menuFoodItem);
            await _context.SaveChangesAsync();

            return menuFoodItem;
        }

        private bool MenuFoodItemExists(int id)
        {
            return _context.MenuFoodItems.Any(e => e.MenuId == id);
        }
    }
}
