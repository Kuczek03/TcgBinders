using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TcgBindersReloaded;
using TcgBindersReloaded.Entities;

namespace TcgBindersReloaded.Controllers
{
    public class CardGameController : Controller
    {
        private readonly BindersContext _context;

        public CardGameController(BindersContext context)
        {
            _context = context;
        }

        // GET: CardGame
        public async Task<IActionResult> Index()
        {
            return View(await _context.CardGames.ToListAsync());
        }

        // GET: CardGame/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardGame = await _context.CardGames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardGame == null)
            {
                return NotFound();
            }

            return View(cardGame);
        }

        // GET: CardGame/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardGame/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Tag,Description,Image")] CardGame cardGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardGame);
        }

        // GET: CardGame/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardGame = await _context.CardGames.FindAsync(id);
            if (cardGame == null)
            {
                return NotFound();
            }
            return View(cardGame);
        }

        // POST: CardGame/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Tag,Description,Image")] CardGame cardGame)
        {
            if (id != cardGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardGameExists(cardGame.Id))
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
            return View(cardGame);
        }

        // GET: CardGame/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardGame = await _context.CardGames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardGame == null)
            {
                return NotFound();
            }

            return View(cardGame);
        }

        // POST: CardGame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardGame = await _context.CardGames.FindAsync(id);
            if (cardGame != null)
            {
                _context.CardGames.Remove(cardGame);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardGameExists(int id)
        {
            return _context.CardGames.Any(e => e.Id == id);
        }
    }
}
