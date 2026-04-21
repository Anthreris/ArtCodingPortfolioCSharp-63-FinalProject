using Microsoft.AspNetCore.Mvc;

namespace ArtAndCodingPortfolio.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}