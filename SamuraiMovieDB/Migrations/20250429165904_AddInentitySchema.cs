using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SamuraiMovieDB.Migrations
{
    /// <inheritdoc />
    public partial class AddInentitySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Movies",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Color", "Description", "Director", "Name", "Year" },
                values: new object[,]
                {
                    { 1, false, "Widely regarded as one of the greatest samurai films of all time, 'Seven Samurai' pioneered the now-iconic 'assemble a team' trope. The story follows a group of six seasoned samurai and a seventh, less experienced warrior who band together to defend a village from ruthless bandits. Their heroic efforts lead to victory, but at a tremendous cost, leaving a lasting impact on the villagers and the samurai.", "Akira Kurosawa", "Seven Samurai", 1954 },
                    { 2, false, "'Yojimbo' tells the tale of a wandering samurai who arrives in a village torn apart by two rival gangs. Using his cunning and swordsmanship, he manipulates the gangs against each other to restore peace. This film inspired the 'man with no name' archetype, later popularized in Western cinema by Sergio Leone.", "Akira Kurosawa", "Yojimbo", 1961 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movies",
                newName: "ID");
        }
    }
}
