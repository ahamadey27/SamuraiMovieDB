using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SamuraiMovieDB;
using SamuraiMovieDB.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


// Restore account confirmation requirement
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true) 
    .AddEntityFrameworkStores<ApplicationDbContext>();

//add support for Razor Pages to the application. Razor Pages are a simplified way to build server-side web applications in ASP.NET Core.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Correct order: Authentication must come before Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
