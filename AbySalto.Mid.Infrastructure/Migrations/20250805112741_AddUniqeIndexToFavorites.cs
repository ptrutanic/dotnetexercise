using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbySalto.Mid.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqeIndexToFavorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId_ExternalProductId",
                table: "Favorites",
                columns: new[] { "UserId", "ExternalProductId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Favorites_UserId_ExternalProductId",
                table: "Favorites");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");
        }
    }
}
