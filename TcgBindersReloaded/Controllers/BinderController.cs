using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TcgBindersReloaded.Entities;

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
    public async Task<IActionResult> Index()
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
}