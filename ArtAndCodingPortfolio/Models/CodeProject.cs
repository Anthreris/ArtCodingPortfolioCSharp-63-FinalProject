namespace ArtAndCodingPortfolio.Models;

public class CodeProject
{
    public int CodeProjectID  { get; set; }
    public required string Title  { get; set; }
    public string? Description { get; set; }
    public string? TechStack { get; set; }
    public string? GitHubUrl  { get; set; }
    public DateTime DateAdded { get; set; } = DateTime.Now;
    public int SortOrder { get; set; }
    public bool IsHidden { get; set; } = false;
}