using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceCenima.Migrations
{
    /// <inheritdoc />
    public partial class AddTrailerProperity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieTrailerUrl",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieTrailerUrl",
                table: "Movies");
        }
    }
}
