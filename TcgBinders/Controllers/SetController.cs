using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TcgBinders.Data;
using TcgBinders.Entities;

namespace TcgBinders.Controllers
{
    public class SetController : Controller
    {
        private readonly BindersContext _context;

        public SetController(BindersContext context)
        {
            _context = context;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sets.ToListAsync());
        }

        // GET
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sets = await _context.Sets
                .FirstOrDefaultAsync(m => m.id == id);
            if (sets == null)
            {
                return NotFound();
            }

            return View(sets);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description,tag,no_of_cards,image,game_tag")] Sets sets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sets);
        }

        // GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sets = await _context.Sets.FindAsync(id);
            if (sets == null)
            {
                return NotFound();
            }
            return View(sets);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description,tag,no_of_cards,image,game_tag")] Sets sets)
        {
            if (id != sets.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetsExists(sets.id))
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
            return View(sets);
        }

        // GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sets = await _context.Sets
                .FirstOrDefaultAsync(m => m.id == id);
            if (sets == null)
            {
                return NotFound();
            }

            return View(sets);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sets = await _context.Sets.FindAsync(id);
            if (sets != null)
            {
                _context.Sets.Remove(sets);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SetsExists(int id)
        {
            return _context.Sets.Any(e => e.id == id);
        }
    }
}
