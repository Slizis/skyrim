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
    public class EnchantmentsController : Controller
    {
        private readonly DataDbContext _context;

        public EnchantmentsController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Enchantments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enchantments.ToListAsync());
        }

        // GET: Enchantments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enchantment = await _context.Enchantments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enchantment == null)
            {
                return NotFound();
            }

            return View(enchantment);
        }

        // GET: Enchantments/Create
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enchantments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,Ench_name,Type,Duration")] Enchantment enchantment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enchantment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enchantment);
        }

        // GET: Enchantments/Edit/5
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enchantment = await _context.Enchantments.FindAsync(id);
            if (enchantment == null)
            {
                return NotFound();
            }
            return View(enchantment);
        }

        // POST: Enchantments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ench_name,Type,Duration")] Enchantment enchantment)
        {
            if (id != enchantment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enchantment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnchantmentExists(enchantment.Id))
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
            return View(enchantment);
        }

        // GET: Enchantments/Delete/5
        [Authorize(Roles = "SuperAdmin, admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enchantment = await _context.Enchantments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enchantment == null)
            {
                return NotFound();
            }

            return View(enchantment);
        }

        // POST: Enchantments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enchantment = await _context.Enchantments.FindAsync(id);
            _context.Enchantments.Remove(enchantment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnchantmentExists(int id)
        {
            return _context.Enchantments.Any(e => e.Id == id);
        }
    }
}
