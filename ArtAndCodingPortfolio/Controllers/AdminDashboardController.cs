using Microsoft.AspNetCore.Mvc;

namespace ArtAndCodingPortfolio.Controllers;

public class AdminDashboardController : Controller
{
    // private readonly ApplicationDbContext _dbContext;
    //
    // public AdminDashboardController(ApplicationDbContext dbContext) //Should have only 1 per code project. since this is highlighted incorrect probably not used in this project.
    // {
    //     _dbContext = dbContext;
    // }
    
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