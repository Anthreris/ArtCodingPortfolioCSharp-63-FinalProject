using Microsoft.AspNetCore.Mvc;

namespace ArtAndCodingPortfolio.Controllers;

public class CodeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}