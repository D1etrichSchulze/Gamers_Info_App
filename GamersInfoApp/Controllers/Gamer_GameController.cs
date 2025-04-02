using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamersInfoApp.Data;
using GamersInfoApp.Models;

namespace GamersInfoApp.Controllers
{
    public class Gamer_GameController : Controller
    {
        private readonly GamersInfoAppContext _context;

        public Gamer_GameController(GamersInfoAppContext context)
        {
            _context = context;
        }

        // GET: Gamer_Game
        public async Task<IActionResult> Index()
        {
            var gamersInfoAppContext = _context.Gamer_Game.Include(g => g.Game).Include(g => g.Gamer);
            return View(await gamersInfoAppContext.ToListAsync());
        }

        // GET: Gamer_Game/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamer_Game = await _context.Gamer_Game
                .Include(g => g.Game)
                .Include(g => g.Gamer)
                .FirstOrDefaultAsync(m => m.GamerGameID == id);
            if (gamer_Game == null)
            {
                return NotFound();
            }

            return View(gamer_Game);
        }

        // GET: Gamer_Game/Create
        public IActionResult Create()
        {
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "GameName");
            ViewData["GamerID"] = new SelectList(_context.Gamer, "GamerID", "GamerName");
            return View();
        }

        // POST: Gamer_Game/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GamerGameID,GamerID,GameID,HoursPlayed")] Gamer_Game gamer_Game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamer_Game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "GameID", gamer_Game.GameID);
            ViewData["GamerID"] = new SelectList(_context.Gamer, "GamerID", "GamerName", gamer_Game.GamerID);
            return View(gamer_Game);
        }

        // GET: Gamer_Game/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamer_Game = await _context.Gamer_Game.FindAsync(id);
            if (gamer_Game == null)
            {
                return NotFound();
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "GameID", gamer_Game.GameID);
            ViewData["GamerID"] = new SelectList(_context.Gamer, "GamerID", "GamerID", gamer_Game.GamerID);
            return View(gamer_Game);
        }

        // POST: Gamer_Game/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GamerGameID,GamerID,GameID,HoursPlayed")] Gamer_Game gamer_Game)
        {
            if (id != gamer_Game.GamerGameID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamer_Game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Gamer_GameExists(gamer_Game.GamerGameID))
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
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "GameID", gamer_Game.GameID);
            ViewData["GamerID"] = new SelectList(_context.Gamer, "GamerID", "GamerID", gamer_Game.GamerID);
            return View(gamer_Game);
        }

        // GET: Gamer_Game/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamer_Game = await _context.Gamer_Game
                .Include(g => g.Game)
                .Include(g => g.Gamer)
                .FirstOrDefaultAsync(m => m.GamerGameID == id);
            if (gamer_Game == null)
            {
                return NotFound();
            }

            return View(gamer_Game);
        }

        // POST: Gamer_Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gamer_Game = await _context.Gamer_Game.FindAsync(id);
            if (gamer_Game != null)
            {
                _context.Gamer_Game.Remove(gamer_Game);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Gamer_GameExists(int id)
        {
            return _context.Gamer_Game.Any(e => e.GamerGameID == id);
        }
    }
}
