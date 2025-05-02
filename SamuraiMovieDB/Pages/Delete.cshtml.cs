using Microsoft.AspNetCore.Authorization; // <-- ADDED
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; // For database operations
using SamuraiMovieDB.Data;
using SamuraiMovieDB.Models;
using System.Threading.Tasks; // For async methods

namespace SamuraiMovieDB.Pages
{
    [Authorize] // <-- ADDED
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie? Movie { get; set; } // Changed Movie to Movie? and removed '= default!'

        public async Task<IActionResult> OnGetAsync(int? id) // id comes from the route
        {
            if (id == null)
            {
                return NotFound();
            }

            // Find the movie by ID to display its details for confirmation
            Movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound(); // Movie not found
            }
            return Page(); // Show the confirmation page with movie details
        }
        
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
        
            // Find the movie again, just to be sure it exists before deleting
            var movieToDelete = await _context.Movies.FindAsync(id); // FindAsync is efficient for finding by PK
        
            if (movieToDelete != null)
            {
                // Remove the movie from the DbContext
                _context.Movies.Remove(movieToDelete);
                // Save the changes to the database
                await _context.SaveChangesAsync();
            }
            // Whether the movie was found and deleted or not found initially,
            // redirect back to the Index page.
            return RedirectToPage("./Index");
        }
    }
}