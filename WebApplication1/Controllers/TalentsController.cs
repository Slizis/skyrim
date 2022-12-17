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
    public class TalentsController : Controller
    {
        private readonly DataDbContext _context;

        public TalentsController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Talents
        public async Task<IActionResult> Index()
        {
            var dataDbContext = _context.Talents.Include(t => t.Player);
            return View(await dataDbContext.ToListAsync());
        }

        // GET: Talents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talent = await _context.Talents
                .Include(t => t.Player)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (talent == null)
            {
                return NotFound();
            }

            return View(talent);
        }

        // GET: Talents/Create
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public IActionResult Create()
        {
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id");
            return View();
        }

        // POST: Talents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,Talent_name,Talent_type,Duration,Player_Id")] Talent talent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(talent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id", talent.Player_Id);
            return View(talent);
        }

        // GET: Talents/Edit/5
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talent = await _context.Talents.FindAsync(id);
            if (talent == null)
            {
                return NotFound();
            }
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id", talent.Player_Id);
            return View(talent);
        }

        // POST: Talents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Talent_name,Talent_type,Duration,Player_Id")] Talent talent)
        {
            if (id != talent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(talent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TalentExists(talent.Id))
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
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id", talent.Player_Id);
            return View(talent);
        }

        // GET: Talents/Delete/5
        [Authorize(Roles = "SuperAdmin, admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talent = await _context.Talents
                .Include(t => t.Player)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (talent == null)
            {
                return NotFound();
            }

            return View(talent);
        }

        // POST: Talents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var talent = await _context.Talents.FindAsync(id);
            _context.Talents.Remove(talent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TalentExists(int id)
        {
            return _context.Talents.Any(e => e.Id == id);
        }
    }
}
