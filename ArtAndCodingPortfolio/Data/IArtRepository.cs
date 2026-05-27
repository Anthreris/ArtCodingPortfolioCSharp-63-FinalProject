using ArtAndCodingPortfolio.Models;

namespace ArtAndCodingPortfolio.Data;

public interface IArtRepository
{
    public IEnumerable<ArtPieceModel> GetAllArtPieces();
    ArtPieceModel? GetArtPiece(int id);
    public void InsertArtPiece(ArtPieceModel artPieceToInsert);
    public void UpdateArtPiece(ArtPieceModel artPieceToUpdate);
    public void DeleteArtPiece(ArtPieceModel artPieceToDelete);
}