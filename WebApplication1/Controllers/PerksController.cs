using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class PerksController : Controller
    {
        private readonly DataDbContext _context;

        public PerksController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Perks
        public async Task<IActionResult> Index()
        {
            var dataDbContext = _context.Perks.Include(p => p.Player);
            return View(await dataDbContext.ToListAsync());
        }

        // GET: Perks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perks = await _context.Perks
                .Include(p => p.Player)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perks == null)
            {
                return NotFound();
            }

            return View(perks);
        }

        // GET: Perks/Create
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public IActionResult Create()
        {
            ViewData["Player_Id"] = new SelectList(_context.Players, "Id", "Id");
            return View();
        }

        // POST: Perks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,access_lvl,Class,Effect,Player_Id")] Perks perks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Player_Id"] = new SelectList(_context.Players, "Id", "Id", perks.Player_Id);
            return View(perks);
        }

        // GET: Perks/Edit/5
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perks = await _context.Perks.FindAsync(id);
            if (perks == null)
            {
                return NotFound();
            }
            ViewData["Player_Id"] = new SelectList(_context.Players, "Id", "Id", perks.Player_Id);
            return View(perks);

        }

        // POST: Perks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,access_lvl,Class,Effect,Player_Id")] Perks perks)
        {
            if (id != perks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerksExists(perks.Id))
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
            ViewData["Player_Id"] = new SelectList(_context.Players, "Id", "Id", perks.Player_Id);
            return View(perks);
        }

        // GET: Perks/Delete/5
        [Authorize(Roles = "SuperAdmin, admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perks = await _context.Perks
                .Include(p => p.Player)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perks == null)
            {
                return NotFound();
            }
            
            return View(perks);
        }

        // POST: Perks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perks = await _context.Perks.FindAsync(id);
            _context.Perks.Remove(perks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerksExists(int id)
        {
            return _context.Perks.Any(e => e.Id == id);
        }
    }
}
