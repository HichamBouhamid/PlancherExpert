using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlancherExpert.Data;
using PlancherExpert.Models;

namespace PlancherExpert.Controllers
{
    public class CouvrePlanchersController : Controller
    {
        private readonly AppDbContext _context;

        public CouvrePlanchersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CouvrePlanchers
        public async Task<IActionResult> Index()
        {
              return _context.CouvrePlancher != null ? 
                          View(await _context.CouvrePlancher.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.CouvrePlancher'  is null.");
        }

        // GET: CouvrePlanchers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CouvrePlancher == null)
            {
                return NotFound();
            }

            var couvrePlancher = await _context.CouvrePlancher
                .FirstOrDefaultAsync(m => m.id == id);
            if (couvrePlancher == null)
            {
                return NotFound();
            }

            return View(couvrePlancher);
        }

        // GET: CouvrePlanchers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CouvrePlanchers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("prixMa,prixMo,type,id")] CouvrePlancher couvrePlancher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(couvrePlancher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(couvrePlancher);
        }

        // GET: CouvrePlanchers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CouvrePlancher == null)
            {
                return NotFound();
            }

            var couvrePlancher = await _context.CouvrePlancher.FindAsync(id);
            if (couvrePlancher == null)
            {
                return NotFound();
            }
            return View(couvrePlancher);
        }

        // POST: CouvrePlanchers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("prixMa,prixMo,type,id")] CouvrePlancher couvrePlancher)
        {
            if (id != couvrePlancher.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(couvrePlancher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CouvrePlancherExists(couvrePlancher.id))
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
            return View(couvrePlancher);
        }

        // GET: CouvrePlanchers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CouvrePlancher == null)
            {
                return NotFound();
            }

            var couvrePlancher = await _context.CouvrePlancher
                .FirstOrDefaultAsync(m => m.id == id);
            if (couvrePlancher == null)
            {
                return NotFound();
            }

            return View(couvrePlancher);
        }

        // POST: CouvrePlanchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CouvrePlancher == null)
            {
                return Problem("Entity set 'AppDbContext.CouvrePlancher'  is null.");
            }
            var couvrePlancher = await _context.CouvrePlancher.FindAsync(id);
            if (couvrePlancher != null)
            {
                _context.CouvrePlancher.Remove(couvrePlancher);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CouvrePlancherExists(int id)
        {
          return (_context.CouvrePlancher?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
