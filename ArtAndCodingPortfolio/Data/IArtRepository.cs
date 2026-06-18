using ArtAndCodingPortfolio.Models;

namespace ArtAndCodingPortfolio.Data;

public interface IArtRepository
{
    public IEnumerable<ArtPiece> GetAllArtPieces();
    ArtPiece? GetArtPiece(int id);
    public void UpdateArtPiece(ArtPiece art);
    public void InsertArtPiece(ArtPiece artPieceToInsert);
    public void DeleteArtPiece(ArtPiece art);
}