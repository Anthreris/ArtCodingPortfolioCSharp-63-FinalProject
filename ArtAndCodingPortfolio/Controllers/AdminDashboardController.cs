using Microsoft.AspNetCore.Mvc;
using ArtAndCodingPortfolio.Filters;
using ArtAndCodingPortfolio.Data;
using ArtAndCodingPortfolio.Models;

namespace ArtAndCodingPortfolio.Controllers;

[AdminOnly]
public class AdminDashboardController : Controller
{
    private readonly IArtRepository _artRepository;
    private readonly IWebHostEnvironment _env;
    public AdminDashboardController(IArtRepository artRepository, IWebHostEnvironment env)
    {
        _artRepository = artRepository;
        _env = env;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddArtPiece()
    {
        return View();    
    }

    [HttpPost]
    public async Task<IActionResult> AddArtPiece(ArtPiece artPiece, IFormFile imageFile)
    {
        if (imageFile != null && imageFile.Length > 0)
        {
            var fileName = Path.GetFileName(imageFile.FileName);
            var savePath = Path.Combine(_env.WebRootPath, "ArtImages", fileName);

            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            artPiece.ImagePath = $"/ArtImages/{fileName}";
        }   
            _artRepository.InsertArtPiece(artPiece);
            return RedirectToAction("Index");
    }

    // [HttpPatch]
    // public async Task<IActionResult> UpdateArtPiece(ArtPiece artPiece, IFormFile imageFile)
    // {
    //     if (imageFile != null && imageFile.Length > 0 )
    //     {
    //         var fileName = Path.GetFileName(imageFile.FileName);
    //         var savePath = Path.Combine(_env.WebRootPath, "ArtImages", fileName);

    //         using var stream = new FileStream(savePath, FileMode, Update))
    //     }
    // }
}