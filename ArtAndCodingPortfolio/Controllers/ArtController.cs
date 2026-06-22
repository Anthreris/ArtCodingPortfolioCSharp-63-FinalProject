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

    public IActionResult View(int id)
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
        ArtPiece? art = _repo.GetArtPiece(id);
        if (art == null)
        {
            return View("ArtPieceNotFound");
        }
        return View(art);
    }
    
    public IActionResult UpdateArtPieceToDatabase(ArtPiece artPieceToUpdate)
    {
        _repo.UpdateArtPiece(artPieceToUpdate);
        return RedirectToAction("ViewArt", new { id = artPieceToUpdate.ArtPieceID });
    }
    
    public IActionResult InsertArtPiece(ArtPiece artPieceToInsert)
    {
       _repo.InsertArtPiece(artPieceToInsert);
       return RedirectToAction("Index");
    }

    public IActionResult List()
    {
        var items = _repo.GetAllArtPieces();
        return View(items);
    }
    
    public IActionResult DeleteArtPiece(ArtPiece art)
    {
        _repo.DeleteArtPiece(art);
        return RedirectToAction("Index");
    }
}