using ArtAndCodingPortfolio.Models;

namespace ArtAndCodingPortfolio.Data;

public interface ICodeRepository
{
    public IEnumerable<CodeProject> GetAllCodeProjects();
    public IEnumerable<CodeProject> GetAllCodeProjectsForAdmin();
    CodeProject? GetCodeProject(int id);
    public void InsertCodeProject(CodeProject codeProjectToInsert);
    public void UpdateCodeProject(CodeProject code);
    public void DeleteCodeProject(CodeProject code);
}