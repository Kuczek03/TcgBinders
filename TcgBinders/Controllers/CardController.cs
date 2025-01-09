using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TcgBinders.Data;
using TcgBinders.Entities;

namespace TcgBinders.Controllers
{
    public class CardController : Controller
    {
        private readonly BindersContext _context;

        public CardController(BindersContext context)
        {
            _context = context;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cards.ToListAsync());
        }

        // GET
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cards = await _context.Cards
                .FirstOrDefaultAsync(m => m.id == id);
            if (cards == null)
            {
                return NotFound();
            }

            return View(cards);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,rarity,type,description,no_in_set,image")] Card cards)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cards);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cards);
        }

        // GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cards = await _context.Cards.FindAsync(id);
            if (cards == null)
            {
                return NotFound();
            }
            return View(cards);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,rarity,type,description,no_in_set,image")] Card cards)
        {
            if (id != cards.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cards);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardsExists(cards.id))
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
            return View(cards);
        }

        // GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cards = await _context.Cards
                .FirstOrDefaultAsync(m => m.id == id);
            if (cards == null)
            {
                return NotFound();
            }

            return View(cards);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cards = await _context.Cards.FindAsync(id);
            if (cards != null)
            {
                _context.Cards.Remove(cards);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardsExists(int id)
        {
            return _context.Cards.Any(e => e.id == id);
        }
    }
}
