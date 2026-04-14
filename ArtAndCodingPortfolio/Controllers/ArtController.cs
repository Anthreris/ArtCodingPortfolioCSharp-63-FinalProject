using Microsoft.AspNetCore.Mvc;

namespace ArtAndCodingPortfolio.Controllers;

public class ArtController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}