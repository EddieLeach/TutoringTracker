using Microsoft.EntityFrameworkCore;
using TutoringTracker.Data;

var builder = WebApplication.CreateBuilder(args);

// Register EF Core + SQLite
var dbPath = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"
    ? "tutoring.db"                // local dev (same as before)
    : "/home/tutoring.db";         // Azure App Service (writable)

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));


// Add Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

// Ensure the SQLite database exists and is up-to-date
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); // creates DB and tables if they don't exist
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();      // ✅ serves wwwroot files

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();       // ✅ maps Razor Pages

app.Run();
