using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCapsule.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(3,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => new { x.GenreId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adventure" },
                    { 20, "Western" },
                    { 19, "War" },
                    { 18, "Thriller" },
                    { 17, "Sport" },
                    { 15, "Romance" },
                    { 14, "Mystery" },
                    { 13, "Musical" },
                    { 12, "Horror" },
                    { 11, "History" },
                    { 16, "Sci-Fi" },
                    { 9, "Family" },
                    { 8, "Drama" },
                    { 7, "Documentary" },
                    { 6, "Crime" },
                    { 5, "Comedy" },
                    { 4, "Biography" },
                    { 3, "Animation" },
                    { 2, "Action" },
                    { 10, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Rating", "Title", "Year" },
                values: new object[,]
                {
                    { 10, 8.1m, "Persona", 1966 },
                    { 9, 8.6m, "Life Is Beautiful", 1997 },
                    { 8, 7.9m, "Arrival", 2016 },
                    { 7, 8.4m, "Like Stars On Earth", 2007 },
                    { 6, 8.6m, "Parasite", 2019 },
                    { 2, 8.8m, "The Lord of the Rings: The Fellowship of the Ring", 2001 },
                    { 4, 7.2m, "Free Guy", 2021 },
                    { 3, 8.6m, "Interstellar", 2014 },
                    { 1, 7.4m, "John Wick", 2014 },
                    { 11, 7.1m, "Cars", 2006 },
                    { 5, 8.4m, "Oldboy", 2003 },
                    { 12, 8.1m, "Gone Girl", 2014 }
                });

            migrationBuilder.InsertData(
                table: "MovieGenre",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 8, 12 },
                    { 5, 11 },
                    { 3, 11 },
                    { 1, 11 },
                    { 18, 10 },
                    { 8, 10 },
                    { 15, 9 },
                    { 8, 9 },
                    { 5, 9 },
                    { 16, 8 },
                    { 8, 8 },
                    { 9, 7 },
                    { 8, 7 },
                    { 18, 6 },
                    { 14, 12 },
                    { 8, 6 },
                    { 14, 5 },
                    { 8, 5 },
                    { 2, 5 },
                    { 5, 4 },
                    { 2, 4 },
                    { 1, 4 },
                    { 16, 3 },
                    { 8, 3 },
                    { 1, 3 },
                    { 8, 2 },
                    { 2, 2 },
                    { 1, 2 },
                    { 18, 1 },
                    { 6, 1 },
                    { 5, 6 },
                    { 18, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_MovieId",
                table: "MovieGenre",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
