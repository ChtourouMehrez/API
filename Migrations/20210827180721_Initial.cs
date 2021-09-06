using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieId);
                });

            migrationBuilder.CreateTable(
                name: "Conges",
                columns: table => new
                {
                    CongeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CongeNonPaye = table.Column<bool>(type: "bit", nullable: false),
                    ForceMajeur = table.Column<bool>(type: "bit", nullable: false),
                    TauxForceMajeurCompteSolde = table.Column<decimal>(type: "decimal(18,3)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conges", x => x.CongeId);
                });

            migrationBuilder.CreateTable(
                name: "Echelons",
                columns: table => new
                {
                    EchelonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Echelons", x => x.EchelonId);
                });

            migrationBuilder.CreateTable(
                name: "JoursFeries",
                columns: table => new
                {
                    JoursFerieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Chome = table.Column<bool>(type: "bit", nullable: false),
                    Paye = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoursFeries", x => x.JoursFerieId);
                });

            migrationBuilder.CreateTable(
                name: "Organigrammes",
                columns: table => new
                {
                    OrganigrammeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organigrammes", x => x.OrganigrammeId);
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    QualificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeQualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.QualificationId);
                });

            migrationBuilder.CreateTable(
                name: "Regimes",
                columns: table => new
                {
                    RegimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regimes", x => x.RegimeId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDepartements",
                columns: table => new
                {
                    ServiceDepartementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDepartements", x => x.ServiceDepartementId);
                });

            migrationBuilder.CreateTable(
                name: "TypeContrats",
                columns: table => new
                {
                    TypeContratId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeTypeContrat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompterAnciente = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeContrats", x => x.TypeContratId);
                });

            migrationBuilder.CreateTable(
                name: "TypePaie",
                columns: table => new
                {
                    TypePaiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodePaie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Declarer = table.Column<bool>(type: "bit", nullable: false),
                    PECPointage = table.Column<bool>(type: "bit", nullable: false),
                    PECNote = table.Column<bool>(type: "bit", nullable: false),
                    PECPrime = table.Column<bool>(type: "bit", nullable: false),
                    AutreCalcule = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePaie", x => x.TypePaiesId);
                });

            migrationBuilder.CreateTable(
                name: "TypePrimes",
                columns: table => new
                {
                    TypePrimeId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_TypePrimes", x => x.TypePrimeId);
                });

            migrationBuilder.CreateTable(
                name: "GrilleSalaires",
                columns: table => new
                {
                    GrilleSalaireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EchelonId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategorieId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegimeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salaire = table.Column<decimal>(type: "decimal(18,3)", maxLength: 10, nullable: false),
                    NbreMoisAnciente = table.Column<int>(type: "int", nullable: false),
                    DureepourPassage = table.Column<int>(type: "int", nullable: false),
                    EchelonId1 = table.Column<int>(type: "int", nullable: true),
                    CategorieId1 = table.Column<int>(type: "int", nullable: true),
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conges");

            migrationBuilder.DropTable(
                name: "GrilleSalaires");

            migrationBuilder.DropTable(
                name: "JoursFeries");

            migrationBuilder.DropTable(
                name: "Organigrammes");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "ServiceDepartements");

            migrationBuilder.DropTable(
                name: "TypeContrats");

            migrationBuilder.DropTable(
                name: "TypePaie");

            migrationBuilder.DropTable(
                name: "TypePrimes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Echelons");

            migrationBuilder.DropTable(
                name: "Regimes");
        }
    }
}
