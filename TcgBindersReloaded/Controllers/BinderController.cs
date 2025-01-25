using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TcgBindersReloaded.Entities;
using TcgBindersReloaded.Models;

namespace TcgBindersReloaded.Controllers;

[Authorize]
public class BinderController : Controller
{
    private readonly BindersContext _context;

    public BinderController(BindersContext context)
    {
        _context = context;
    }

    // GET
    public async Task<IActionResult> BinderCards()
    {
        var user = HttpContext.User.Identity.Name;
        var binder = _context.Binders
            .Include(p => p.User)
            .Include(p => p.BCards)
            .FirstOrDefault(p => p.User.Username == user);

        if (binder == null)
        {
            return View(new List<BinderCards>());
        }
        else
        {
            return View(binder.BCards);
        }
    }
    
    // GET
    public async Task<IActionResult> UserCards()
    {
        var user = HttpContext.User.Identity.Name;
        var binder = _context.CollectionCards
            .Include(p => p.User)
            .Include(p => p.Card)
            .FirstOrDefault(p => p.User.Username == user);

        if (binder == null)
        {
            return View(new List<Card>());
        }
        else
        {
            return View(binder.Card);
        }
    }
    
    // GET
    public async Task<IActionResult> BinderList()
    {
        var user = HttpContext.User.Identity.Name;
        var binder = _context.Users
            .Include(b => b.Binders)
            .FirstOrDefault(u => u.Username == user);

        if (binder == null)
        {
            return View(new List<Binder>());
        }
        else
        {
            return View(binder.Binders);
        }
    }

    
    // GET
    public IActionResult BinderCreate()
    {
        return View();
    }
    
    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BinderCreate(BinderViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = HttpContext.User.Identity.Name;
            var userId = _context.Users.FirstOrDefault(u => u.Username == user)?.Id;
        
            Binder binder = new Binder();
            binder.UserId = userId.Value;
            binder.Name = model.Name;
        
            if (userId == null)
            {
                ModelState.AddModelError("", "User not found");
                return View(model);
            }
            
            try
            {
                _context.Add(binder);
                _context.SaveChangesAsync();
                ModelState.Clear();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                ModelState.AddModelError("", "Cannot create new binder");
                return View(model);
            }
            return RedirectToAction("BinderList");
        }
        return View(model);
    }
}