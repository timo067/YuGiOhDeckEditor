using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YuGiOhDeckEditor.Data;
using YuGiOhDeckEditor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Get the connection string for database context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Add the DbContext to the DI container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add Identity for user authentication
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Register MVC controllers and views
builder.Services.AddControllersWithViews();

// Register HttpClient using IHttpClientFactory
builder.Services.AddHttpClient();  // Adds the HttpClient factory for making HTTP requests

// Register your custom service for external API calls
builder.Services.AddScoped<ExternalApiService>();  // Register the external API service

// Register database developer page exception filter for development environments
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Show detailed errors in development
    app.UseMigrationsEndPoint();  // Use migrations endpoint for development
}
else
{
    app.UseExceptionHandler("/Home/Error");  // Handle errors in production
    app.UseHsts();  // Enforce HTTPS
}

// Middleware for HTTPS redirection and static files
app.UseHttpsRedirection();
app.UseStaticFiles();

// Configure routing and authorization
app.UseRouting();
app.UseAuthorization();

// Set up default routing for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  // Default route pattern

// Map Razor Pages (if needed for identity or additional views)
app.MapRazorPages();

// Run the app
app.Run();

