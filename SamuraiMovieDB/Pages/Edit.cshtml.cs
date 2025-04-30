using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; // For database operations like FindAsync and Attach/Modified
using SamuraiMovieDB.Data;
using SamuraiMovieDB.Models;
using System.Threading.Tasks; // For async methods

//Define the Class: Create a public class EditModel that inherits from PageModel:
namespace SamuraiMovieDB.Pages
{
    public class EditModel : PageModel
    {
        //Inject DbContext: Add a private readonly field for ApplicationDbContext and a constructor 
        //to inject it (similar to the ContributeModel):
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        //Add BindProperty: Create a public property Movie of type Movie and decorate it with[BindProperty]. 
        //This will hold the movie data for the form
        [BindProperty]
        public Movie Movie { get; set; } = default!;
        //Implement OnGetAsync: This method handles the initial request for the Edit page. 
        //It needs to accept the movie's Id as a parameter (usually from the URL route).
        public async Task<IActionResult> OnGetAsync(int? id) //id comes from the route
        {
            if (id == null)
            {
                return NotFound(); //// No ID provided
            }

#pragma warning disable CS8601 // Possible null reference assignment.
            Movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);  // Find the movie in the database by its ID
#pragma warning restore CS8601 // Possible null reference assignment.
            if (Movie == null)
            {
                return NotFound(); // Movie with that ID doesn't exist
            }
            return Page();
        }

        //Implement OnPostAsync: This method handles the form submission when the user saves changes
        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the submitted data is valid according to model rules
            if (!ModelState.IsValid)
            {
                return Page(); // Return the page with validation errors
            }

            // Attach the Movie object to the context and mark it as modified
            _context.Attach(Movie).State = EntityState.Modified;

            try
            {
                // Attempt to save the changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle potential concurrency issues (e.g., if someone else deleted the movie)
                if (!MovieExists(Movie.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw; // Re-throw the exception if it's unexpected
                }
            }

            // Redirect back to the Index page after successful update
            return RedirectToPage("./Index");

        }
        //Add Helper Method (Optional but good practice): 
        // Add a private method to check if a movie exists, used in the catch block above
        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}




