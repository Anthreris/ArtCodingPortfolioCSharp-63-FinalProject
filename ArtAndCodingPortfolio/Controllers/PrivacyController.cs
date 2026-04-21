using Microsoft.AspNetCore.Mvc;

namespace ArtAndCodingPortfolio.Controllers;

public class PrivacyController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}