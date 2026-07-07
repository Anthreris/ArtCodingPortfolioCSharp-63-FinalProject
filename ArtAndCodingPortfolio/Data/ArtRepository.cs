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
        return _connection.Query<ArtPiece>("SELECT * FROM artprojects WHERE IsHidden = 0 ORDER BY SortOrder");
    }

    public IEnumerable<ArtPiece> GetAllArtPiecesForAdmin()
    {
        return _connection.Query<ArtPiece>("SELECT * FROM artprojects ORDER BY SortOrder");
    }

    public ArtPiece? GetArtPiece(int id)
    {
        return _connection.QuerySingleOrDefault<ArtPiece>("SELECT * FROM artprojects WHERE ArtPieceID = @ArtPieceID", new { ArtPieceID = id});
    }
    
    public void UpdateArtPiece(ArtPiece artPieceToUpdate)
    {
        _connection.Execute(@"UPDATE artprojects SET Title = @Title, Description = @Description, ImagePath = @Imagepath, SortOrder = @Sortorder, IsHidden = @IsHidden WHERE ArtPieceID = @ArtPieceID", artPieceToUpdate);
    }
    
    public void InsertArtPiece(ArtPiece artPieceToInsert)
    {
        _connection.Execute(@"INSERT INTO artprojects (Title, Description, ImagePath, DateAdded, SortOrder, IsHidden)  VALUES (@Title, @Description, @Imagepath, @Dateadded, @Sortorder, @IsHidden)", artPieceToInsert);
    }

    public void DeleteArtPiece(ArtPiece artPieceToDelete)
    {
        _connection.Execute("DELETE FROM artprojects WHERE ArtPieceID = @ArtPieceID;", new {artPieceToDelete.ArtPieceID});
    }
}