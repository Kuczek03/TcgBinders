using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TcgBinders.Data;
using TcgBinders.Models;

namespace TcgBinders.Controllers
{
    public class GameController : Controller
    {
        private readonly BindersContext _context;

        public GameController(BindersContext context)
        {
            _context = context;
        }

        // GET: Game
        public async Task<IActionResult> Index()
        {
            return View(await _context.Games.ToListAsync());
        }

        // GET: Game/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                .FirstOrDefaultAsync(m => m.id == id);
            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // GET: Game/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,tag,description,image")] Games games)
        {
            if (ModelState.IsValid)
            {
                _context.Add(games);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(games);
        }

        // GET: Game/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games.FindAsync(id);
            if (games == null)
            {
                return NotFound();
            }
            return View(games);
        }

        // POST: Game/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,tag,description,image")] Games games)
        {
            if (id != games.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(games);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamesExists(games.id))
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
            return View(games);
        }

        // GET: Game/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                .FirstOrDefaultAsync(m => m.id == id);
            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var games = await _context.Games.FindAsync(id);
            if (games != null)
            {
                _context.Games.Remove(games);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamesExists(int id)
        {
            return _context.Games.Any(e => e.id == id);
        }
    }
}
