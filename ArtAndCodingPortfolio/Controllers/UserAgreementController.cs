using Microsoft.AspNetCore.Mvc;

namespace ArtAndCodingPortfolio.Controllers;

public class UserAgreementController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}