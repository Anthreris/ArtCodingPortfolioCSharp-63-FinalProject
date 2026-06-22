using System.Data;
using Dapper;
using ArtAndCodingPortfolio.Models;

namespace ArtAndCodingPortfolio.Data;

public class CodeRepository : ICodeRepository
{
    private readonly IDbConnection _connection;

    public CodeRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<CodeProjectModel> GetAllCodeProjects()
    {
        return _connection.Query<CodeProjectModel>("SELECT * FROM CODEPROJECTS WHERE IsHidden = false ORDER BY SortOrder");
    }

    public CodeProjectModel? GetCodeProject(int id)
    {
        return _connection.QuerySingle<CodeProjectModel>("SELECT * FROM CODEPROJECTS WHERE CodeProjectId = @CodeProjectId", new { CodeProjectId = id });
    }

    public void UpdateCodeProject(CodeProjectModel codeProjectToUpdate)
    {
        _connection.Execute("UPDATE CODEPROJECTS SET Title = @Title, Description = @Description, TechStack = @Techstack, GitHubUrl = @GithubUrl, SortOrder = @Sortorder, IsHidden = @IsHidden WHERE CodeProjectId = @CodeProjectId", codeProjectToUpdate);
    }
    
    public void InsertCodeProject(CodeProjectModel codeProjectToInsert)
    {
        _connection.Execute("INSERT INTO CODEPROJECTS (Title, Description, TechStack, GitHubUrl, DateAdded, SortOrder, IsHidden)  VALUES (@Title, @Description, @TechStack, @GitHubUrl, @DateAdded, @SortOrder, @IsHidden)", codeProjectToInsert);
    }

    public void DeleteCodeProject(CodeProjectModel codeProjectToDelete)
    {
        _connection.Execute("DELETE FROM CODEPROJECTS WHERE CodeProjectId = @CodeProjectId;", codeProjectToDelete);
    }
}