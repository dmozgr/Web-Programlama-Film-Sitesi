using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgrammingMovie.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Movie_UrunId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_UrunId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "UrunId",
                table: "Photo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Photo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UrunId",
                table: "Photo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_UrunId",
                table: "Photo",
                column: "UrunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Movie_UrunId",
                table: "Photo",
                column: "UrunId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
