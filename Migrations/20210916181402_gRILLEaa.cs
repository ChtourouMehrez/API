using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class gRILLEaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grilles_Regimes_RegimeId",
                table: "Grilles");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Natures_NatureId",
                table: "Personnels");

            migrationBuilder.DropIndex(
                name: "IX_Personnels_NatureId",
                table: "Personnels");

            migrationBuilder.DropColumn(
                name: "NatureId",
                table: "Personnels");

            migrationBuilder.RenameColumn(
                name: "sexe",
                table: "Personnels",
                newName: "Sexe");

            migrationBuilder.RenameColumn(
                name: "RegimeId",
                table: "Grilles",
                newName: "QualificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Grilles_RegimeId",
                table: "Grilles",
                newName: "IX_Grilles_QualificationId");

            migrationBuilder.AlterColumn<decimal>(
                name: "CoefConge",
                table: "Personnels",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "EnfantPersonnels",
                columns: table => new
                {
                    EnfantPersonnelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelKey = table.Column<int>(type: "int", nullable: false),
                    SessionKey = table.Column<int>(type: "int", nullable: false),
                    NomPrenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Situation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hendicape = table.Column<bool>(type: "bit", nullable: false),
                    EnCharge = table.Column<bool>(type: "bit", nullable: false),
                    EtudiantNonBoursier = table.Column<bool>(type: "bit", nullable: false),
                    SessionKey1 = table.Column<int>(type: "int", nullable: true),
                    PersonnelKey1 = table.Column<int>(type: "int", nullable: true),
                    PersonnelSessionKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnfantPersonnels", x => x.EnfantPersonnelId);
                    table.ForeignKey(
                        name: "FK_EnfantPersonnels_Personnels_PersonnelKey1_PersonnelSessionKey",
                        columns: x => new { x.PersonnelKey1, x.PersonnelSessionKey },
                        principalTable: "Personnels",
                        principalColumns: new[] { "PersonnelKey", "SessionKey" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnfantPersonnels_Sessions_SessionKey1",
                        column: x => x.SessionKey1,
                        principalTable: "Sessions",
                        principalColumn: "SessionKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnfantPersonnels_PersonnelKey1_PersonnelSessionKey",
                table: "EnfantPersonnels",
                columns: new[] { "PersonnelKey1", "PersonnelSessionKey" });

            migrationBuilder.CreateIndex(
                name: "IX_EnfantPersonnels_SessionKey1",
                table: "EnfantPersonnels",
                column: "SessionKey1");

            migrationBuilder.AddForeignKey(
                name: "FK_Grilles_Qualifications_QualificationId",
                table: "Grilles",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "QualificationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grilles_Qualifications_QualificationId",
                table: "Grilles");

            migrationBuilder.DropTable(
                name: "EnfantPersonnels");

            migrationBuilder.RenameColumn(
                name: "Sexe",
                table: "Personnels",
                newName: "sexe");

            migrationBuilder.RenameColumn(
                name: "QualificationId",
                table: "Grilles",
                newName: "RegimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Grilles_QualificationId",
                table: "Grilles",
                newName: "IX_Grilles_RegimeId");

            migrationBuilder.AlterColumn<int>(
                name: "CoefConge",
                table: "Personnels",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "NatureId",
                table: "Personnels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_NatureId",
                table: "Personnels",
                column: "NatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grilles_Regimes_RegimeId",
                table: "Grilles",
                column: "RegimeId",
                principalTable: "Regimes",
                principalColumn: "RegimeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Natures_NatureId",
                table: "Personnels",
                column: "NatureId",
                principalTable: "Natures",
                principalColumn: "NatureId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
