using System.Data;
using Dapper;
using ArtAndCodingPortfolio.Models;
using MySql.Data.MySqlClient;

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
        return _connection.Query<CodeProjectModel>("SELECT * FROM CODEPROJECTS");
    }

    public CodeProjectModel? GetCodeProject(int id)
    {
        return _connection.QuerySingle<CodeProjectModel>("SELECT * FROM CODEPROJECTS WHERE CODEPPROJECTID = @id", new { id });
    }

    public void UpdateCodeProject(CodeProjectModel codeProjectToUpdate)
    {
        _connection.Execute("UPDATE CODEPROJECTS SET TITLE = @title, DESCRIPTION = @description, TECHSTACK = @techstack, GITHUBURL = @githuburl, SORTORDER = @sortorder");
    }
    
    public void InsertCodeProject(CodeProjectModel codeProjectToInsert)
    {
        _connection.Execute("INSERT INTO CODEPROJECTS (TITLE, DESCRIPTION, TECHSTACK, GITHUBURL, DATEADDED, SORTORDER, CODEPROJECTID)  VALUES (@title, @description, @techstack, @githuburl, @dateadded, @sortorder, @id)");
    }

    public void DeleteCodeProject(CodeProjectModel codeProjectToDelete)
    {
        _connection.Execute("DELETE FROM CODEPROJECTS WHERE CODEPROJECTID = @id;", new { id = codeProjectToDelete.CodeProjectID });
    }
}