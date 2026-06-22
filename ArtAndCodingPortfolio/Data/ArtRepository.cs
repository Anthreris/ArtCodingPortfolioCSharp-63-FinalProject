using System.Data;
using Dapper;
using ArtAndCodingPortfolio.Models;

namespace ArtAndCodingPortfolio.Data;

public class ArtRepository : IArtRepository
{
    private readonly IDbConnection _connection;

    public ArtRepository(IDbConnection connection)
    {
        _connection = connection;
    }
        
    public IEnumerable<ArtPiece> GetAllArtPieces()
    {
        return _connection.Query<ArtPiece>("SELECT * FROM ARTPROJECTS WHERE IsHidden = false ORDER BY SortOrder");
    }

    public ArtPiece? GetArtPiece(int id)
    {
        return _connection.QuerySingle<ArtPiece>("SELECT * FROM ARTPROJECTS WHERE ArtPieceId = @ArtPieceId", new { ArtPieceId = id});
    }
    
    public void UpdateArtPiece(ArtPiece artPieceToUpdate)
    {
        _connection.Execute("UPDATE ARTPROJECTS SET Title = @Title, Description = @Description, ImagePath = @Imagepath, SortOrder = @Sortorder, IsHidden = @IsHidden WHERE ARTPIECE ID = @ArtPieceID", artPieceToUpdate);
    }
    
    public void InsertArtPiece(ArtPiece artPieceToInsert)
    {
        _connection.Execute("INSERT INTO ARTPROJECTS (Title, Description, ImagePath, DateAdded, SortOrder, IsHidden)  VALUES (@Title, @Description, @Imagepath, @Dateadded, @Sortorder, @IsHidden)", artPieceToInsert);
    }

    public void DeleteArtPiece(ArtPiece artPieceToDelete)
    {
        _connection.Execute("DELETE FROM ARTPROJECTS WHERE ArtPieceId = @ArtPieceId;", artPieceToDelete);
    }
}