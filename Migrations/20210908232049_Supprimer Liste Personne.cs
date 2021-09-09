using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class SupprimerListePersonne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Sessions_SessionKey",
                table: "Personnels");

            migrationBuilder.DropIndex(
                name: "IX_Personnels_SessionKey",
                table: "Personnels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Personnels_SessionKey",
                table: "Personnels",
                column: "SessionKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Sessions_SessionKey",
                table: "Personnels",
                column: "SessionKey",
                principalTable: "Sessions",
                principalColumn: "SessionKey",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
