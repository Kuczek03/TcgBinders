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
    public class TcgGamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TcgGamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TcgGames
        public async Task<IActionResult> Index()
        {
            return View(await _context.TcgGames.ToListAsync());
        }

        // GET: TcgGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tcgGames = await _context.TcgGames
                .FirstOrDefaultAsync(m => m.id == id);
            if (tcgGames == null)
            {
                return NotFound();
            }

            return View(tcgGames);
        }

        // GET: TcgGames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TcgGames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,game_name,game_tag,no_of_sets")] TcgGames tcgGames)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tcgGames);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tcgGames);
        }

        // GET: TcgGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tcgGames = await _context.TcgGames.FindAsync(id);
            if (tcgGames == null)
            {
                return NotFound();
            }
            return View(tcgGames);
        }

        // POST: TcgGames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,game_name,game_tag,no_of_sets")] TcgGames tcgGames)
        {
            if (id != tcgGames.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tcgGames);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TcgGamesExists(tcgGames.id))
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
            return View(tcgGames);
        }

        // GET: TcgGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tcgGames = await _context.TcgGames
                .FirstOrDefaultAsync(m => m.id == id);
            if (tcgGames == null)
            {
                return NotFound();
            }

            return View(tcgGames);
        }

        // POST: TcgGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tcgGames = await _context.TcgGames.FindAsync(id);
            if (tcgGames != null)
            {
                _context.TcgGames.Remove(tcgGames);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TcgGamesExists(int id)
        {
            return _context.TcgGames.Any(e => e.id == id);
        }
    }
}
