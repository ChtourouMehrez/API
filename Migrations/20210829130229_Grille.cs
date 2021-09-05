using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Grille : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrilleSalaires");

            migrationBuilder.CreateTable(
                name: "Grilles",
                columns: table => new
                {
                    GrilleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegimeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategorieId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EchelonId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NbreMoisAnciente = table.Column<int>(type: "int", nullable: false),
                    DureepourPassage = table.Column<int>(type: "int", nullable: false),
                    Salaire = table.Column<int>(type: "int", nullable: false),
                    RegimeId1 = table.Column<int>(type: "int", nullable: true),
                    CategorieId1 = table.Column<int>(type: "int", nullable: true),
                    EchelonId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grilles", x => x.GrilleId);
                    table.ForeignKey(
                        name: "FK_Grilles_Categories_CategorieId1",
                        column: x => x.CategorieId1,
                        principalTable: "Categories",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grilles_Echelons_EchelonId1",
                        column: x => x.EchelonId1,
                        principalTable: "Echelons",
                        principalColumn: "EchelonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grilles_Regimes_RegimeId1",
                        column: x => x.RegimeId1,
                        principalTable: "Regimes",
                        principalColumn: "RegimeId",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grilles");

            migrationBuilder.CreateTable(
                name: "GrilleSalaires",
                columns: table => new
                {
                    GrilleSalaireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategorieId1 = table.Column<int>(type: "int", nullable: true),
                    DureepourPassage = table.Column<int>(type: "int", nullable: false),
                    EchelonId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EchelonId1 = table.Column<int>(type: "int", nullable: true),
                    NbreMoisAnciente = table.Column<int>(type: "int", nullable: false),
                    RegimeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegimeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrilleSalaires", x => x.GrilleSalaireId);
                    table.ForeignKey(
                        name: "FK_GrilleSalaires_Categories_CategorieId1",
                        column: x => x.CategorieId1,
                        principalTable: "Categories",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GrilleSalaires_Echelons_EchelonId1",
                        column: x => x.EchelonId1,
                        principalTable: "Echelons",
                        principalColumn: "EchelonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GrilleSalaires_Regimes_RegimeId1",
                        column: x => x.RegimeId1,
                        principalTable: "Regimes",
                        principalColumn: "RegimeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrilleSalaires_CategorieId1",
                table: "GrilleSalaires",
                column: "CategorieId1");

            migrationBuilder.CreateIndex(
                name: "IX_GrilleSalaires_EchelonId1",
                table: "GrilleSalaires",
                column: "EchelonId1");

            migrationBuilder.CreateIndex(
                name: "IX_GrilleSalaires_RegimeId1",
                table: "GrilleSalaires",
                column: "RegimeId1");
        }
    }
}
