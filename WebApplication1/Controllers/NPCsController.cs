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
    public class NPCsController : Controller
    {
        private readonly DataDbContext _context;

        public NPCsController(DataDbContext context)
        {
            _context = context;
        }

        // GET: NPCs
        public async Task<IActionResult> Index()
        {
            var dataDbContext = _context.NPCs.Include(n => n.Biom);
            return View(await dataDbContext.ToListAsync());
        }

        // GET: NPCs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nPC = await _context.NPCs
                .Include(n => n.Biom)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nPC == null)
            {
                return NotFound();
            }

            return View(nPC);
        }

        // GET: NPCs/Create
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public IActionResult Create()
        {
            ViewData["BiomId"] = new SelectList(_context.Bioms, "Id", "Id");
            return View();
        }

        // POST: NPCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,NPC_name,HP,MP,Fraction,Biom_Id")] NPC nPC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nPC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BiomId"] = new SelectList(_context.Bioms, "Id", "Id", nPC.Biom_Id);
            return View(nPC);
        }

        // GET: NPCs/Edit/5
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nPC = await _context.NPCs.FindAsync(id);
            if (nPC == null)
            {
                return NotFound();
            }
            ViewData["BiomId"] = new SelectList(_context.Bioms, "Id", "Id", nPC.Biom_Id);
            return View(nPC);
        }

        // POST: NPCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NPC_name,HP,MP,Fraction,Biom_Id")] NPC nPC)
        {
            if (id != nPC.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nPC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NPCExists(nPC.Id))
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
            ViewData["BiomId"] = new SelectList(_context.Bioms, "Id", "Id", nPC.Biom_Id);
            return View(nPC);
        }

        // GET: NPCs/Delete/5
        [Authorize(Roles = "SuperAdmin, admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nPC = await _context.NPCs
                .Include(n =>n.Biom)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nPC == null)
            {
                return NotFound();
            }

            return View(nPC);
        }

        // POST: NPCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nPC = await _context.NPCs.FindAsync(id);
            _context.NPCs.Remove(nPC);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NPCExists(int id)
        {
            return _context.NPCs.Any(e => e.Id == id);
        }
    }
}
