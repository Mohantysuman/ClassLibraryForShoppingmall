using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibraryForShoppingmall.Model;
using ClassLibraryForShoppingmall.ShoppingDbContext;

namespace ShoppingMallsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingsController : ControllerBase
    {
        private readonly ShoppingMallDbContext _context;

        public ShoppingsController(ShoppingMallDbContext context)
        {
            _context = context;
        }

        // GET: api/Shoppings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shopping>>> GetMalls()
        {
          if (_context.Malls == null)
          {
              return NotFound();
          }
            return await _context.Malls.ToListAsync();
        }

        // GET: api/Shoppings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shopping>> GetShopping(int id)
        {
          if (_context.Malls == null)
          {
              return NotFound();
          }
            var shopping = await _context.Malls.FindAsync(id);

            if (shopping == null)
            {
                return NotFound();
            }

            return shopping;
        }

        // PUT: api/Shoppings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopping(int id, Shopping shopping)
        {
            if (id != shopping.Id)
            {
                return BadRequest();
            }

            _context.Entry(shopping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Shoppings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shopping>> PostShopping(Shopping shopping)
        {
          if (_context.Malls == null)
          {
              return Problem("Entity set 'ShoppingMallDbContext.Malls'  is null.");
          }
            _context.Malls.Add(shopping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopping", new { id = shopping.Id }, shopping);
        }

        // DELETE: api/Shoppings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopping(int id)
        {
            if (_context.Malls == null)
            {
                return NotFound();
            }
            var shopping = await _context.Malls.FindAsync(id);
            if (shopping == null)
            {
                return NotFound();
            }

            _context.Malls.Remove(shopping);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoppingExists(int id)
        {
            return (_context.Malls?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
