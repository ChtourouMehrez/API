using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Grilles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Grilles_CategorieId",
                table: "Grilles",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Grilles_EchelonId",
                table: "Grilles",
                column: "EchelonId");

            migrationBuilder.CreateIndex(
                name: "IX_Grilles_RegimeId",
                table: "Grilles",
                column: "RegimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grilles_Categories_CategorieId",
                table: "Grilles",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grilles_Echelons_EchelonId",
                table: "Grilles",
                column: "EchelonId",
                principalTable: "Echelons",
                principalColumn: "EchelonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grilles_Regimes_RegimeId",
                table: "Grilles",
                column: "RegimeId",
                principalTable: "Regimes",
                principalColumn: "RegimeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grilles_Categories_CategorieId",
                table: "Grilles");

            migrationBuilder.DropForeignKey(
                name: "FK_Grilles_Echelons_EchelonId",
                table: "Grilles");

            migrationBuilder.DropForeignKey(
                name: "FK_Grilles_Regimes_RegimeId",
                table: "Grilles");

            migrationBuilder.DropIndex(
                name: "IX_Grilles_CategorieId",
                table: "Grilles");

            migrationBuilder.DropIndex(
                name: "IX_Grilles_EchelonId",
                table: "Grilles");

            migrationBuilder.DropIndex(
                name: "IX_Grilles_RegimeId",
                table: "Grilles");
        }
    }
}
