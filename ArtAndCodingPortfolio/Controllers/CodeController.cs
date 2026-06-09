using Microsoft.AspNetCore.Mvc;
using ArtAndCodingPortfolio.Data;
using ArtAndCodingPortfolio.Models;

namespace ArtAndCodingPortfolio.Controllers;

public class CodeController : Controller
{
    private readonly ICodeRepository _repo;
    
    public CodeController(ICodeRepository repo)
    {
        _repo = repo;
    }
    
    public IActionResult Index()
    {
        var code = _repo.GetAllCodeProjects();
        return View(code);
    }
    
    public IActionResult ViewCode(int id)
    {
        var code = _repo.GetCodeProject(id);
        if (code == null)
        {
            return NotFound();
        }
        return View(code);
    }

    public IActionResult UpdateCodeProject(int id)
    {
        CodeProjectModel code = _repo.GetCodeProject(id);
        if (code == null)
        {
            return View("CodeProjectNotFound");
        }
        return View(code);
    }

    public IActionResult UpdateCodeProjectToDatabase(CodeProjectModel codeProjectToUpdate)
    {
        _repo.UpdateCodeProject(codeProjectToUpdate);
        return RedirectToAction("ViewCode", new { id = codeProjectToUpdate.CodeProjectID });
    }

    // public IActionResult InsertCodeProject()
    // {
    //     var code = _repo.InsertCodeProject();
    //     return View(code);
    // }

    public IActionResult DeleteCodeProject(CodeProjectModel code)
    {
        _repo.DeleteCodeProject(code);
        return RedirectToAction("Index");
    }
}