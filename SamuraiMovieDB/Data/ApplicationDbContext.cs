using Microsoft.AspNetCore.Identity; // Provides built-in support for ASP.NET Core Identity, which is used for authentication and user management.
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Provides the base classes for integrating ASP.NET Core Identity with Entity Framework Core.
using Microsoft.EntityFrameworkCore; // Provides the Entity Framework Core functionality for working with databases.
using SamuraiMovieDB.Models; // Imports the namespace containing the application's models, such as the `Movie` class.

namespace SamuraiMovieDB.Data
{
    // Defines the application's database context, which is used to interact with the database.
    // Inherits from `IdentityDbContext<IdentityUser>` to include ASP.NET Core Identity functionality.
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext()
        {
        }

        // Constructor that accepts options for configuring the database context.
        // These options are typically provided by the dependency injection system.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        // Represents the `Movies` table in the database.
        // The `DbSet<Movie>` property allows querying and saving instances of the `Movie` class.
        public DbSet<Movie> Movies { get; set; } // Generic type parameter of DbSet specifies the entity type.

        // Configures the model and relationships for the database context.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Calls the base implementation to ensure Identity-related configurations are applied.
            base.OnModelCreating(builder);

            // Configures the `Movie` entity.
            // Adds a unique index on the combination of the `Name` and `Year` properties of the `Movie` entity.
            // This ensures that no two movies in the database can have the same name and year.
            builder.Entity<Movie>()
                .HasIndex(m => new { m.Name, m.Year }) // Composite index on `Name` and `Year`.
                .IsUnique(); // Ensures the index is unique.

            //Seeds/populates inital data for Movies
            builder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Name = "Seven Samurai",
                    Year = 1954,
                    Director = "Akira Kurosawa",
                    Color = false,
                    Description = "Widely regarded as one of the greatest samurai films of all time, 'Seven Samurai' pioneered the " +
                                  "now-iconic 'assemble a team' trope. The story follows a group of six seasoned samurai and a seventh, " +
                                  "less experienced warrior who band together to defend a village from ruthless bandits. Their heroic " +
                                  "efforts lead to victory, but at a tremendous cost, leaving a lasting impact on the villagers and the samurai."
                },

                new Movie
                {
                    Id = 2,
                    Name = "Yojimbo",
                    Year = 1961,
                    Director = "Akira Kurosawa",
                    Color = false,
                    Description = "'Yojimbo' tells the tale of a wandering samurai who arrives in a village torn apart by two rival gangs. " +
                                  "Using his cunning and swordsmanship, he manipulates the gangs against each other to restore peace. " +
                                  "This film inspired the 'man with no name' archetype, later popularized in Western cinema by Sergio Leone."
                }
            );
        }
    }
}