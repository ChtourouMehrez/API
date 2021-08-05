using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddTypePrimesTypePaiesTypeContrats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeContrats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeTypeContrat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompterAnciente = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeContrats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypePaies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codePaie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Declarer = table.Column<bool>(type: "bit", nullable: false),
                    PECPointage = table.Column<bool>(type: "bit", nullable: false),
                    PECNote = table.Column<bool>(type: "bit", nullable: false),
                    PECPrime = table.Column<bool>(type: "bit", nullable: false),
                    AutreCalcule = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePaies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypePrimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodePrime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cotisable = table.Column<bool>(type: "bit", nullable: false),
                    Imposable = table.Column<bool>(type: "bit", nullable: false),
                    Fixe = table.Column<bool>(type: "bit", nullable: false),
                    PointageNormal = table.Column<bool>(type: "bit", nullable: false),
                    Horaire = table.Column<bool>(type: "bit", nullable: false),
                    PriseConsideration = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePrimes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeContrats");

            migrationBuilder.DropTable(
                name: "TypePaies");

            migrationBuilder.DropTable(
                name: "TypePrimes");
        }
    }
}
