// Name: Jeassen Andrew Silitonga
// NIM: 2481037
// Course: Framework .NET Programming

using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// Register MVC and API controller services.
builder.Services.AddControllersWithViews();

// Read the connection string from user secrets.
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Missing database connection.");

// Register the database context with MySQL.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, new MariaDbServerVersion(new Version(10, 4, 32))));

var app = builder.Build();

// Configure production error handling.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Serve static files such as CSS and JavaScript.
app.UseStaticFiles();

// Enable HTTP request routing.
app.UseRouting();

// Enable authorization middleware.
app.UseAuthorization();

// Configure the default MVC route.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Enable attribute-routed API controllers.
app.MapControllers();

// Seed sample data (development only).
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await StudentSeeder.SeedAsync(db);
}

// Start the application.
app.Run();