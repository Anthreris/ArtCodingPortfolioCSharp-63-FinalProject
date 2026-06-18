using ArtAndCodingPortfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtAndCodingPortfolio.Data;

public class PortfolioDbContext : DbContext
{
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { } 
    public DbSet<ArtPiece> ArtPieces { get; set; }
    public DbSet<CodeProjectModel> CodeProjects { get; set; }
}