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
    
    public IEnumerable<CodeProject> GetAllCodeProjects()
    {
        return _connection.Query<CodeProject>("SELECT * FROM codeprojects WHERE IsHidden = 0 ORDER BY SortOrder");
    }

    public IEnumerable<CodeProject> GetAllCodeProjectsForAdmin()
    {
        return _connection.Query<CodeProject>("SELECT * FROM codeprojects ORDER BY SortOrder");
    }

    public CodeProject? GetCodeProject(int id)
    {
        return _connection.QuerySingleOrDefault<CodeProject>("SELECT * FROM codeprojects WHERE CodeProjectId = @CodeProjectId", new { CodeProjectId = id });
    }

    public void UpdateCodeProject(CodeProject codeProjectToUpdate)
    {
        _connection.Execute(@"UPDATE codeprojects SET Title = @Title, Description = @Description, TechStack = @Techstack, GitHubUrl = @GithubUrl, SortOrder = @Sortorder, IsHidden = @IsHidden WHERE CodeProjectId = @CodeProjectId", codeProjectToUpdate);
    }
   
    public void InsertCodeProject(CodeProject codeProjectToInsert)
    {
        _connection.Execute(@"INSERT INTO codeprojects (Title, Description, TechStack, GitHubUrl, DateAdded, SortOrder, IsHidden)  VALUES (@Title, @Description, @TechStack, @GitHubUrl, @DateAdded, @SortOrder, @IsHidden)", codeProjectToInsert);
    }

    public void DeleteCodeProject(CodeProject codeProjectToDelete)
    {
        _connection.Execute("DELETE FROM codeprojects WHERE CodeProjectId = @CodeProjectId;", new {codeProjectToDelete.CodeProjectID});
    }
}