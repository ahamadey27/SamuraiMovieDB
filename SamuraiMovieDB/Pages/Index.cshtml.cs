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

    // Constructor to initialize the logger and database context via dependency injection.
    public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
    {
        _logger = logger; // Assign the injected logger to the private field.
        _context = context; // Assign the injected database context to the private field.
    }

    // Method that is executed when the page is accessed via an HTTP GET request.
    public void OnGet()
    {
        // Create a new instance of the database context (this is unnecessary since _context is already injected).
        // This approach can lead to issues such as multiple context instances being created.
        using (var context = new ApplicationDbContext())
        {
            // Retrieve all movies from the database and assign them to the Movies property.
            Movies = context.Movies.ToList();
        }
    }
}