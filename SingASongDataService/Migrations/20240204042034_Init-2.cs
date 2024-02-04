using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SingASongDataService.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CartTracks_CartId",
                table: "CartTracks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartTracks",
                table: "CartTracks",
                columns: new[] { "CartId", "TrackId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CartTracks",
                table: "CartTracks");

            migrationBuilder.CreateIndex(
                name: "IX_CartTracks_CartId",
                table: "CartTracks",
                column: "CartId");
        }
    }
}
