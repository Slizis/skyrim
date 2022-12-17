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
    public class QuestsController : Controller
    {
        private readonly DataDbContext _context;

        public QuestsController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Quests
        public async Task<IActionResult> Index()
        {
            var dataDbContext = _context.Quests.Include(q => q.Player).Include(q => q.NPC);
            return View(await dataDbContext.ToListAsync());
        }

        // GET: Quests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quest = await _context.Quests
                .Include(q => q.Player)
                .Include(q => q.NPC)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quest == null)
            {
                return NotFound();
            }

            return View(quest);
        }

        // GET: Quests/Create
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public IActionResult Create()
        {
            ViewData["Player_Id"] = new SelectList(_context.Players, "Id", "Id");
            ViewData["NPC_Id"] = new SelectList(_context.NPCs, "Id", "Id");
            return View();
        }

        // POST: Quests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,Receving,acess_lvl,Recewing,NPC_Id,Player_Id")] Quest quest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Player_Id"] = new SelectList(_context.Players, "Id", "Id", quest.Player_Id);
            ViewData["NPC_Id"] = new SelectList(_context.NPCs, "Id", "Id", quest.NPC_Id);
            return View(quest);
        }

        // GET: Quests/Edit/5
        [Authorize(Roles = "SuperAdmin, admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quest = await _context.Quests.FindAsync(id);
            if (quest == null)
            {
                return NotFound();
            }
            ViewData["Player_Id"] = new SelectList(_context.Players, "Id", "Id", quest.Player_Id);
            ViewData["NPC_Id"] = new SelectList(_context.NPCs, "Id", "Id", quest.NPC_Id);
            return View(quest);
        }

        // POST: Quests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Receving,acess_lvl,Recewing,NPC_Id,Player_Id")] Quest quest)
        {
            if (id != quest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestExists(quest.Id))
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
            ViewData["Player_Id"] = new SelectList(_context.Players, "Id", "Id", quest.Player_Id);
            ViewData["NPC_Id"] = new SelectList(_context.NPCs, "Id", "Id", quest.NPC_Id);
            return View(quest);
        }

        // GET: Quests/Delete/5
        [Authorize(Roles = "SuperAdmin, admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quest = await _context.Quests
                .Include(q => q.Player)
                .Include(q => q.NPC)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quest == null)
            {
                return NotFound();
            }

            return View(quest);
        }

        // POST: Quests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quest = await _context.Quests.FindAsync(id);
            _context.Quests.Remove(quest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestExists(int id)
        {
            return _context.Quests.Any(e => e.Id == id);
        }
    }
}
