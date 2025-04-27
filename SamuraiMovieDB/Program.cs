using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SamuraiMovieDB;
using SamuraiMovieDB.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Purpose: This line registers the ApplicationDbContext with the dependency injection (DI) container and configures it to use SQLite as the database provider.
// AddDbContext<ApplicationDbContext>: Adds the ApplicationDbContext to the DI container so it can be injected into other parts of the application
// UseSqlite: Configures Entity Framework Core to use SQLite as the database provider.
// builder.Configuration.GetConnectionString("DefaultConnection"): Retrieves the connection string named "DefaultConnection" from appsettings.json.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Purpose: This line sets up ASP.NET Core Identity for user authentication and authorization.
// AddDefaultIdentity<IdentityUser>: Adds the default implementation of ASP.NET Core Identity with the IdentityUser class as the user model.
// options.SignIn.RequireConfirmedAccount = true: Configures Identity to require email confirmation before a user can sign in.
// .AddEntityFrameworkStores<ApplicationDbContext>: Configures Identity to use the ApplicationDbContext for storing user data in the database.
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

//add support for Razor Pages to the application. Razor Pages are a simplified way to build server-side web applications in ASP.NET Core.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
