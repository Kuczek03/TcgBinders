using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TcgBindersReloaded.Entities;
using TcgBindersReloaded.Models;

namespace TcgBindersReloaded.Controllers;

public class AccountController : Controller
{
    private readonly BindersContext _context;

    public AccountController(BindersContext bindersContext)
    {
        _context = bindersContext;
    }
    
    // GET
    [Authorize]
    public IActionResult Users()
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
            account.Email = model.Email;
            account.Username = model.Username;
            account.Password = model.Password;
            account.CreationDate = DateOnly.FromDateTime(DateTime.Now);
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
            return RedirectToAction("Login");
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
            var user = _context.Users.Where(x => (x.Username == model.UsernameEmail || 
                                                  x.Email == model.UsernameEmail) && x.Password == model.Password)
                .FirstOrDefault();
            
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, "User"),
                };
                
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                
                return RedirectToAction("Users");
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
        return RedirectToAction("Index", "Home");
    }
    
    [Authorize]
    public IActionResult SecurePage()
    {
        ViewBag.Name = HttpContext.User.Identity.Name;
        return View();
    }
}