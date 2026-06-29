using Microsoft.AspNetCore.Mvc;
using ArtAndCodingPortfolio.Filters;

namespace ArtAndCodingPortfolio.Controllers;

[AdminOnly]
public class AdminDashboardController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AddPage()
    {
        throw new NotImplementedException();
    }

    public IActionResult EditPage()
    {
        throw new NotImplementedException();
    }

    public IActionResult DeletePage()
    {
        throw new NotImplementedException();
    }

    public IActionResult HidePage()
    {
        throw new NotImplementedException();
    }
}