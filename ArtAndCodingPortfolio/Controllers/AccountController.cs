using Microsoft.AspNetCore.Mvc;

namespace ArtAndCodingPortfolio.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var adminUser = HttpContext.RequestServices.GetRequiredService<IConfiguration>()["Admin:Username"];
        var adminHash = HttpContext.RequestServices.GetRequiredService<IConfiguration>()["Admin:PasswordHash"];

        if (username == adminUser && BCrypt.Net.BCrypt.Verify(password, adminHash))
        {
            HttpContext.Session.SetString("IsAdmin", "true");
            return RedirectToAction("Index", "AdminDashboard");
        } 
        
        ViewBag.Error = "Invalid Credentials";

        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}