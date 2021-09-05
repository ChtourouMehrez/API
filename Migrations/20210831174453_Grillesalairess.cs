using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Grillesalairess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grilles_Categories_CategorieId1",
                table: "Grilles");

            migrationBuilder.DropForeignKey(
                name: "FK_Grilles_Echelons_EchelonId1",
                table: "Grilles");

            migrationBuilder.DropForeignKey(
                name: "FK_Grilles_Regimes_RegimeId1",
                table: "Grilles");

            migrationBuilder.DropIndex(
                name: "IX_Grilles_CategorieId1",
                table: "Grilles");

            migrationBuilder.DropIndex(
                name: "IX_Grilles_EchelonId1",
                table: "Grilles");

            migrationBuilder.DropIndex(
                name: "IX_Grilles_RegimeId1",
                table: "Grilles");

            migrationBuilder.DropColumn(
                name: "CategorieId1",
                table: "Grilles");

            migrationBuilder.DropColumn(
                name: "EchelonId1",
                table: "Grilles");

            migrationBuilder.DropColumn(
                name: "RegimeId1",
                table: "Grilles");

            migrationBuilder.AlterColumn<int>(
                name: "RegimeId",
                table: "Grilles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EchelonId",
                table: "Grilles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Grilles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegimeId",
                table: "Grilles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EchelonId",
                table: "Grilles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CategorieId",
                table: "Grilles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategorieId1",
                table: "Grilles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EchelonId1",
                table: "Grilles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegimeId1",
                table: "Grilles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grilles_CategorieId1",
                table: "Grilles",
                column: "CategorieId1");

            migrationBuilder.CreateIndex(
                name: "IX_Grilles_EchelonId1",
                table: "Grilles",
                column: "EchelonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Grilles_RegimeId1",
                table: "Grilles",
                column: "RegimeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Grilles_Categories_CategorieId1",
                table: "Grilles",
                column: "CategorieId1",
                principalTable: "Categories",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grilles_Echelons_EchelonId1",
                table: "Grilles",
                column: "EchelonId1",
                principalTable: "Echelons",
                principalColumn: "EchelonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grilles_Regimes_RegimeId1",
                table: "Grilles",
                column: "RegimeId1",
                principalTable: "Regimes",
                principalColumn: "RegimeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
