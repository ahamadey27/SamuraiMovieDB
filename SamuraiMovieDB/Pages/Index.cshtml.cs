using Microsoft.AspNetCore.Mvc; // Provides attributes and types for building MVC applications.
using Microsoft.AspNetCore.Mvc.RazorPages; // Provides support for Razor Pages.

namespace SamuraiMovieDB.Pages; // Defines the namespace for the Razor Page.

using SamuraiMovieDB.Models; // Includes the namespace where the Movie model is defined.
using SamuraiMovieDB.Data; // Includes the namespace where the ApplicationDbContext is defined.

public class IndexModel : PageModel // Represents the model for the Index Razor Page.
{
    private readonly ILogger<IndexModel> _logger; // Logger for logging information, warnings, or errors.
    private readonly ApplicationDbContext _context; // Database context for interacting with the database.

    // Property to hold the list of movies retrieved from the database.
    public List<Movie> Movies { get; set; } = new List<Movie>();
    public string? Name { get; set; }
    public int? Year { get; set; }
    public string? Director { get; set; }
    public bool? Color { get; set; }
    public string? Description { get; set; }

    // Constructor to initialize the logger and database context via dependency injection.
    public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
    {
        _logger = logger; // Assign the injected logger to the private field.
        _context = context; // Assign the injected database context to the private field.
    }

    // Method that is executed when the page is accessed via an HTTP GET request.
    public void OnGet(string? name, int? year, string? director, bool? color, string? description)
    {
        Name = name;
        Year = year;
        Director = director;
        Color = color;
        Description = description;

        // Fetch movies from the database 
        var query = _context.Movies.AsQueryable();
        if (!string.IsNullOrEmpty(Name))
        {
            query = query.Where(m => m.Name != null && m.Name.Contains(Name));
        }

        if (Year.HasValue)
        {
            query = query.Where(m => m.Year == Year.Value);
        }

        if (!string.IsNullOrEmpty(Director))
        {
            query = query.Where(m => m.Director != null && m.Director.Contains(Director));
        }

        if (Color.HasValue)
        {
            query = query.Where(m => m.Color == Color.Value);
        }

        if (!string.IsNullOrEmpty(Description))
        {
            query = query.Where(m => m.Description != null && m.Description.Contains(Description));
        }

        Movies = query.ToList();
    }
}