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
    public class SpellsController : Controller
    {
        private readonly DataDbContext _context;

        public SpellsController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Spells
        public async Task<IActionResult> Index()
        {
            var dataDbContext = _context.Spells.Include(s => s.Player).Include(s => s.NPC);
            return View(await dataDbContext.ToListAsync());
        }

        // GET: Spells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spell = await _context.Spells
                .Include(s => s.Player)
                .Include(s => s.NPC)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spell == null)
            {
                return NotFound();
            }

            return View(spell);
        }

        // GET: Spells/Create
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public IActionResult Create()
        {
            ViewData["Player_Id"] = new SelectList(_context.Players, "Id", "Id");
            ViewData["NPC_Id"] = new SelectList(_context.NPCs, "Id", "Id");
            return View();
        }

        // POST: Spells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,Spell_name,MP_cost,Player_Id,NPC_Id")] Spell spell)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Player_Id"] = new SelectList(_context.Players, "Id", "Id", spell.Player_Id);
            ViewData["NPC_Id"] = new SelectList(_context.NPCs, "Id", "Id", spell.NPC_Id);
            return View(spell);
        }

        // GET: Spells/Edit/5
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spell = await _context.Spells.FindAsync(id);
            if (spell == null)
            {
                return NotFound();
            }
            ViewData["Player_Id"] = new SelectList(_context.Players, "Id", "Id", spell.Player_Id);
            ViewData["NPC_Id"] = new SelectList(_context.NPCs, "Id", "Id", spell.NPC_Id);
            return View(spell);
        }

        // POST: Spells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Spell_name,MP_cost,Player_Id,NPC_Id")] Spell spell)
        {
            if (id != spell.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spell);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellExists(spell.Id))
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
            ViewData["Player_Id"] = new SelectList(_context.Players, "Id", "Id", spell.Player_Id);
            ViewData["NPC_Id"] = new SelectList(_context.NPCs, "Id", "Id", spell.NPC_Id);
            return View(spell);
        }

        // GET: Spells/Delete/5
        [Authorize(Roles = "SuperAdmin, admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spell = await _context.Spells
                .Include(s => s.Player)
                .Include(s => s.NPC)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spell == null)
            {
                return NotFound();
            }

            return View(spell);
        }

        // POST: Spells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spell = await _context.Spells.FindAsync(id);
            _context.Spells.Remove(spell);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpellExists(int id)
        {
            return _context.Spells.Any(e => e.Id == id);
        }
    }
}
