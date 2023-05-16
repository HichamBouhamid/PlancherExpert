using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlancherExpertWebServices.Models;

namespace PlancherExpertWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouvrePlanchersController : ControllerBase
    {
        private readonly CouvrePlancherDBContext _context;

        public CouvrePlanchersController(CouvrePlancherDBContext context)
        {
            _context = context;
        }

        // GET: api/CouvrePlanchers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CouvrePlancher>>> GetCouvrePlancher()
        {
          if (_context.CouvrePlancher == null)
          {
              return NotFound();
          }
            return await _context.CouvrePlancher.ToListAsync();
        }

        // GET: api/CouvrePlanchers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CouvrePlancher>> GetCouvrePlancher(int id)
        {
          if (_context.CouvrePlancher == null)
          {
              return NotFound();
          }
            var couvrePlancher = await _context.CouvrePlancher.FindAsync(id);

            if (couvrePlancher == null)
            {
                return NotFound();
            }

            return couvrePlancher;
        }

        // PUT: api/CouvrePlanchers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCouvrePlancher(int id, CouvrePlancher couvrePlancher)
        {
            if (id != couvrePlancher.Id)
            {
                return BadRequest();
            }

            _context.Entry(couvrePlancher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CouvrePlancherExists(id))
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

        // POST: api/CouvrePlanchers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CouvrePlancher>> PostCouvrePlancher(CouvrePlancher couvrePlancher)
        {
          if (_context.CouvrePlancher == null)
          {
              return Problem("Entity set 'CouvrePlancherDBContext.CouvrePlancher'  is null.");
          }
            _context.CouvrePlancher.Add(couvrePlancher);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCouvrePlancher), new {id=couvrePlancher.Id},couvrePlancher);
        }

        // DELETE: api/CouvrePlanchers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCouvrePlancher(int id)
        {
            if (_context.CouvrePlancher == null)
            {
                return NotFound();
            }
            var couvrePlancher = await _context.CouvrePlancher.FindAsync(id);
            if (couvrePlancher == null)
            {
                return NotFound();
            }

            _context.CouvrePlancher.Remove(couvrePlancher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CouvrePlancherExists(int id)
        {
            return (_context.CouvrePlancher?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
