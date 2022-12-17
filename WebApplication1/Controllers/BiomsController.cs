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
    public class BiomsController : Controller
    {
        private readonly DataDbContext _context;

        public BiomsController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Bioms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bioms.ToListAsync());
        }

        // GET: Bioms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biom = await _context.Bioms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biom == null)
            {
                return NotFound();
            }

            return View(biom);
        }

        // GET: Bioms/Create
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bioms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public async Task<IActionResult> Create(Biom biom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(biom);
        }

        // GET: Bioms/Edit/5
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biom = await _context.Bioms.FindAsync(id);
            if (biom == null)
            {
                return NotFound();
            }
            return View(biom);
        }

        // POST: Bioms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Biom_Name,Location,Weather")] Biom biom)
        {
            if (id != biom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiomExists(biom.Id))
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
            return View(biom);
        }

        // GET: Bioms/Delete/5
        [Authorize(Roles = "SuperAdmin, admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biom = await _context.Bioms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biom == null)
            {
                return NotFound();
            }

            return View(biom);
        }

        // POST: Bioms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biom = await _context.Bioms.FindAsync(id);
            _context.Bioms.Remove(biom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiomExists(int id)
        {
            return _context.Bioms.Any(e => e.Id == id);
        }
    }
}
