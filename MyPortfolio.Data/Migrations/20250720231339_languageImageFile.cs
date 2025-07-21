using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class languageImageFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Languages");
        }
    }
}
