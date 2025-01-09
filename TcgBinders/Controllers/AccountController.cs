using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TcgBinders.Data;
using TcgBinders.Models;
using TcgBinders.Entities;

namespace TcgBinders.Controllers;

public class AccountController : Controller
{
    private readonly BindersContext _context;

    public AccountController(BindersContext bindersContext)
    {
        _context = bindersContext;
    }
    
    // GET
    public IActionResult Index()
    {
        return View(_context.Users.ToList());
    }
    
    // GET
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            User account = new User();
            account.email = model.email;
            account.username = model.username;
            account.password = model.password;

            try
            {
                _context.Users.Add(account);
                _context.SaveChanges();

                ModelState.Clear();
                ViewData["Message"] = "Account created successfully, please login.";
            }
            catch (DbUpdateException e)
            {
                ModelState.AddModelError("", "Username, email or password already exists.");
                return View(model);
            }
            return View();
        }
        return View(model);
    }
    
    // GET
    public IActionResult Login()
    {
        return View();
    }
    
    // POST
    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Users.Where(x => (x.username == model.username_email || 
                                                  x.email == model.username_email) && x.password == model.password)
                .FirstOrDefault();
            
            if (user != null)
            {
                //succes = coockie
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.email),
                    new Claim(ClaimTypes.Name, user.username),
                    new Claim(ClaimTypes.Role, "User"),
                };
                
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                
                return RedirectToAction("SecurePage");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username/email or password.");
            }
        }
        return View(model);
    }

    public IActionResult Logout()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index");
    }
    
    [Authorize]
    public IActionResult SecurePage()
    {
        ViewBag.Name = HttpContext.User.Identity.Name;
        return View();
    }
    
}