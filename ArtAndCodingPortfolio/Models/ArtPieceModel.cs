namespace ArtAndCodingPortfolio.Models;

public class ArtPieceModel
{
    public int ArtPieceID { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; } 
    public required string ImagePath { get; set; } 
    public DateTime DateAdded { get; set; } = DateTime.Now;
    public int SortOrder { get; set; }
    public bool IsHidden { get; set; } = false;
}