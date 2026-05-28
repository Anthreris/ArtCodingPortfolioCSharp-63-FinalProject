using ArtAndCodingPortfolio.Models;

namespace ArtAndCodingPortfolio.Data;

public interface ICodeRepository
{
    public IEnumerable<CodeProjectModel> GetAllCodeProjects();
    CodeProjectModel? GetCodeProject(int id);
    public void InsertCodeProject(CodeProjectModel codeProjectToInsert);
    public void UpdateCodeProject(CodeProjectModel codeProjectToUpdate);
    public void DeleteCodeProject(CodeProjectModel codeProjectToDelete);
}