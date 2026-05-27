using System.Data;
using Dapper;
using ArtAndCodingPortfolio.Models;
using MySql.Data.MySqlClient;

namespace ArtAndCodingPortfolio.Data;

public class ArtRepository : IArtRepository
{
    private readonly IDbConnection _connection;

    public ArtRepository(IDbConnection connection)
    {
        _connection = connection;
    }
        
    public IEnumerable<ArtPieceModel> GetAllArtPieces()
    {
        return _connection.Query<ArtPieceModel>("SELECT * FROM ARTPIECE");
    }

    public ArtPieceModel? GetArtPiece(int id)
    {
        return _connection.QuerySingle<ArtPieceModel>("SELECT * FROM ARTPIECE WHERE ARTPIECEID = @id", new { id = id });
    }
    
    public void UpdateArtPiece(ArtPieceModel artPieceToUpdate)
    {
        _connection.Execute("UPDATE ARTPIECE SET Title = @title, Description = @description, ImagePath = @imagepath, SortOrder = @sortorder");
    }
    
    public void InsertArtPiece(ArtPieceModel artPieceToInsert)
    {
        _connection.Execute("INSERT INTO ARTPIECE (TITLE, DESCRIPTION, IMAGEPATH, DATEADDED, SORTORDER, ARTPIECEID)  VALUES (@title, @description, @imagepath, @dateadded, @sortorder, @id)");
    } //DATEADDED or CURRENT_DATE ?

    // public void UpdateTitle(ArtPieceModel artPieceToUpdate)
    // {
    //     _connection.Execute("UPDATE ARTPIECE SET TITLE = @title");
    // }
    //
    // public void UpdateImagePath(ArtPieceModel artPieceToUpdate)
    // {
    //     _connection.Execute("UPDATE ARTPIECE SET IMAGEPATH = @imagepath");
    // }
    //
    // public void UpdateSortOrder(ArtPieceModel artPieceToUpdate)
    // {
    //     _connection.Execute("UPDATE ARTPIECE SET SORTORDER = @sortorder");
    // }

    public void DeleteArtPiece(ArtPieceModel artPieceToDelete)
    {
        _connection.Execute("DELETE FROM ARTPROJECTS WHERE ARTPIECEID = @id;", new { id = artPieceToDelete.ArtPieceID });
    }
}