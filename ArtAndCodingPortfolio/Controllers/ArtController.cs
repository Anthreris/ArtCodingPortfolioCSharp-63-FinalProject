using ArtAndCodingPortfolio.Data;
using Microsoft.AspNetCore.Mvc;
using ArtAndCodingPortfolio.Models;

namespace ArtAndCodingPortfolio.Controllers;

public class ArtController : Controller
{
    private readonly IArtRepository _repo;
    public ArtController(IArtRepository repo)
    {
        _repo = repo;
    }
    
    public IActionResult Index()
    {
        var art = _repo.GetAllArtPieces();
        return View(art);
    }

    public IActionResult ViewArtPiece(int id)
    {
        var art = _repo.GetArtPiece(id);
        if (art == null)
        {
            return NotFound();
        }
        return View(art);
    }
    
    public IActionResult UpdateArtPiece(int id)
    {
        ArtPieceModel art = _repo.GetArtPiece(id);
        if (art == null)
        {
            return View("ArtPieceNotFound");
        }
        return View(art);
    }
    
    public IActionResult UpdateArtPieceToDatabase(ArtPieceModel artPieceToUpdate)
    {
        _repo.UpdateArtPiece(artPieceToUpdate);
        return RedirectToAction("ViewArt", new { id = artPieceToUpdate.ArtPieceID });
    }
    
    // public IActionResult InsertArtPiece()
    // {
    //     var art = _repo.InsertArtPiece();
    //     return View(art);
    // }
    
    public IActionResult DeleteArtPiece(ArtPieceModel art)
    {
        _repo.DeleteArtPiece(art);
        return RedirectToAction("Index");
    }
}