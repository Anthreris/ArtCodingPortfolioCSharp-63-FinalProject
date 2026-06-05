using ArtAndCodingPortfolio.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string not found");
//builder.Services.AddScoped<IDbConnection>(_ =>
builder.Services.AddDbContext<PortfolioDbContext>(options =>
{
    var conn = new MySqlConnection(connectionString);
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    conn.Open();
    //return conn;
});
    //options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
//builder.Services.AddTransient<ICodeRepository, CodeRepository>();

var app = builder.Build();

//Configuring the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();