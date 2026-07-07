using Microsoft.AspNetCore.Mvc;
using ArtAndCodingPortfolio.Filters;
using ArtAndCodingPortfolio.Data;
using ArtAndCodingPortfolio.Models;
using System.Reflection.Metadata.Ecma335;

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
        IEnumerable<ArtPiece> pieces = _artRepository.GetAllArtPiecesForAdmin();
        return View(pieces);
    }

    [HttpGet]
    public IActionResult AddArtPiece()
    {
        return View();    
    }

    [HttpPost]
    public async Task<IActionResult> AddArtPiece(ArtPiece artPiece, IFormFile imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
        {
            ModelState.AddModelError(string.Empty, "Images Required");
            return View(artPiece);
        }
        string fileName = Path.GetFileName(imageFile.FileName);
        string savePath = Path.Combine(_env.WebRootPath, "ArtImages", fileName);

        using (FileStream stream = new FileStream(savePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(stream);
        }

        artPiece.ImagePath = $"/ArtImages/{fileName}";
        artPiece.DateAdded = DateTime.Now;
          
        _artRepository.InsertArtPiece(artPiece);
        return RedirectToAction("Index");
    }
    // Get/AdminDashboard/EditArt/5: Show Edit Form Pre-filled.
    [HttpGet]
    public IActionResult EditArt(int id)
    {
        ArtPiece? piece = _artRepository.GetArtPiece(id);
        if (piece == null) return NotFound();

        return View(piece);
    }
    // Post/AdminDashboard/EditArt: Save Changes
    [HttpPost]
    public async Task<IActionResult> EditArt(ArtPiece artPiece, IFormFile? imageFile)
    {
        ArtPiece? existing = _artRepository.GetArtPiece(artPiece.ArtPieceID);
        if (existing == null) return NotFound();
        
        // Keep old image unless new image uploaded
        if (imageFile != null && imageFile.Length > 0)
        {
            string fileName = Path.GetFileName(imageFile.FileName);
            string savePath = Path.Combine(_env.WebRootPath, "ArtImages", fileName);

            using (FileStream stream = new FileStream(savePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            artPiece.ImagePath = $"/ArtImages/{fileName}";
        }
        else
        {
            artPiece.ImagePath = existing.ImagePath;
        }

        _artRepository.UpdateArtPiece(artPiece);
        return RedirectToAction(nameof(Index));
    }

    // Get/AdminDashboard/DeleteArt/5: Confirm Delete.
    [HttpGet]
    public IActionResult DeleteArt(int id)
    {
        ArtPiece? piece = _artRepository.GetArtPiece(id);
        if (piece == null) return NotFound();

        return View(piece);
    }

    // Post/AdminDashboard/DeleteArt: Actually Delete.
    [HttpPost]
    [ActionName("DeleteArt")]
    public IActionResult DeleteArtConfirmed(int artPieceID)
    {
        ArtPiece? piece = _artRepository.GetArtPiece(artPieceID);
        if (piece == null) return NotFound();

        _artRepository.DeleteArtPiece(piece);
        return RedirectToAction(nameof(Index));
    }

    // Post/AdminDashbaord/HideArt/5: Soft hide from public gallery.
    [HttpPost]
    public IActionResult HideArt(int id)
    {
        ArtPiece? piece = _artRepository.GetArtPiece(id);
        if (piece == null) return NotFound();

        piece.IsHidden = true;
        _artRepository.UpdateArtPiece(piece);
        return RedirectToAction(nameof(Index));
    }

    // Post/AdminDashboard/UnHideArt/5
    [HttpPost]
    public IActionResult UnhideArt(int id)
    {
        ArtPiece? piece = _artRepository.GetArtPiece(id);
        if (piece == null) return NotFound();

        piece.IsHidden = false;
        _artRepository.UpdateArtPiece(piece);
        return RedirectToAction(nameof(Index));
    }
}