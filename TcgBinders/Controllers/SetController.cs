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
    public class SetController : Controller
    {
        private readonly BindersContext _context;

        public SetController(BindersContext context)
        {
            _context = context;
        }

        // GET: Set
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sets.ToListAsync());
        }

        // GET: Set/Details/5
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

        // GET: Set/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Set/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Set/Edit/5
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

        // POST: Set/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Set/Delete/5
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

        // POST: Set/Delete/5
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
