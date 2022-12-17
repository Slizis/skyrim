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
    public class ScreamsController : Controller
    {
        private readonly DataDbContext _context;

        public ScreamsController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Screams
        public async Task<IActionResult> Index()
        {
            var dataDbContext = _context.Screams.Include(s => s.Player);
            return View(await dataDbContext.ToListAsync());
        }

        // GET: Screams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scream = await _context.Screams
                .Include(s => s.Player)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scream == null)
            {
                return NotFound();
            }

            return View(scream);
        }

        // GET: Screams/Create
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public IActionResult Create()
        {
            ViewData["Player_Id"] = new SelectList(_context.Players, "Id", "Id");
            return View();
        }

        // POST: Screams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,Type_Scream,Damage,Duration,Player_Id")] Scream scream)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scream);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Player_Id"] = new SelectList(_context.Players, "Id", "Id", scream.Player_Id);
            return View(scream);
        }

        // GET: Screams/Edit/5
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scream = await _context.Screams.FindAsync(id);
            if (scream == null)
            {
                return NotFound();
            }
            ViewData["Player_Id"] = new SelectList(_context.Players, "Id", "Id", scream.Player_Id);
            return View(scream);
        }

        // POST: Screams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type_Scream,Damage,Duration,Player_Id")] Scream scream)
        {
            if (id != scream.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scream);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScreamExists(scream.Id))
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
            ViewData["Player_Id"] = new SelectList(_context.Players, "Id", "Id", scream.Player_Id);
            return View(scream);
        }

        // GET: Screams/Delete/5
        [Authorize(Roles = "SuperAdmin, admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scream = await _context.Screams
                .Include(s => s.Player)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scream == null)
            {
                return NotFound();
            }

            return View(scream);
        }

        // POST: Screams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scream = await _context.Screams.FindAsync(id);
            _context.Screams.Remove(scream);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScreamExists(int id)
        {
            return _context.Screams.Any(e => e.Id == id);
        }
    }
}
