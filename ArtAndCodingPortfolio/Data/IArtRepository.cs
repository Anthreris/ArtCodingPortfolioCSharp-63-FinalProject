using ArtAndCodingPortfolio.Models;

namespace ArtAndCodingPortfolio.Data;

public interface IArtRepository
{
    IEnumerable<ArtPiece> GetAllArtPieces();
    IEnumerable<ArtPiece> GetAllArtPiecesForAdmin();
    ArtPiece? GetArtPiece(int id);
    void UpdateArtPiece(ArtPiece art);
    void InsertArtPiece(ArtPiece artPieceToInsert);
    void DeleteArtPiece(ArtPiece art);
}