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
    public class CardSetController : Controller
    {
        private readonly BindersContext _context;

        public CardSetController(BindersContext context)
        {
            _context = context;
        }

        // GET: CardSet
        public async Task<IActionResult> Index()
        {
            return View(await _context.CardSets.ToListAsync());
        }

        // GET: CardSet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardSet = await _context.CardSets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardSet == null)
            {
                return NotFound();
            }

            return View(cardSet);
        }

        // GET: CardSet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardSet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Tag,NoOfCards,GameTag,image")] CardSet cardSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardSet);
        }

        // GET: CardSet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardSet = await _context.CardSets.FindAsync(id);
            if (cardSet == null)
            {
                return NotFound();
            }
            return View(cardSet);
        }

        // POST: CardSet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Tag,NoOfCards,GameTag,image")] CardSet cardSet)
        {
            if (id != cardSet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardSetExists(cardSet.Id))
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
            return View(cardSet);
        }

        // GET: CardSet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardSet = await _context.CardSets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardSet == null)
            {
                return NotFound();
            }

            return View(cardSet);
        }

        // POST: CardSet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardSet = await _context.CardSets.FindAsync(id);
            if (cardSet != null)
            {
                _context.CardSets.Remove(cardSet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardSetExists(int id)
        {
            return _context.CardSets.Any(e => e.Id == id);
        }
    }
}
