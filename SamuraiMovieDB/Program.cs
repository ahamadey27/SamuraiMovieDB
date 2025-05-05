using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SamuraiMovieDB.Data;

var builder = WebApplication.CreateBuilder(args);

// 1) Register the SQLite DbContext with a connection string from configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 2) Configure Identity to use EF stores and require confirmed accounts
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// 3) Add Razor Pages support
builder.Services.AddRazorPages();

var app = builder.Build();

// 4) Apply any pending migrations on startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

// 5) Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// 6) Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// 7) Map endpoints
app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
