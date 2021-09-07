using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddLibelleTypePaieModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Libelle",
                table: "TypePaie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroSession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypePaiesId = table.Column<int>(type: "int", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoisSession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exercice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOuverture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserOuverture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cloturer = table.Column<bool>(type: "bit", nullable: false),
                    DateCloture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCloture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trimestre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDebutSession = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFinSession = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionKey);
                    table.ForeignKey(
                        name: "FK_Sessions_TypePaie_TypePaiesId",
                        column: x => x.TypePaiesId,
                        principalTable: "TypePaie",
                        principalColumn: "TypePaiesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personnels",
                columns: table => new
                {
                    PersonnelKey = table.Column<int>(type: "int", nullable: false),
                    SessionKey = table.Column<int>(type: "int", nullable: false),
                    MatriculePersonnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CCB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sexe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EtatCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEmbauche = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCNSS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChefFamille = table.Column<bool>(type: "bit", nullable: false),
                    OrganigrammeId = table.Column<int>(type: "int", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    RegimeId = table.Column<int>(type: "int", nullable: false),
                    QualificationId = table.Column<int>(type: "int", nullable: false),
                    EchelonId = table.Column<int>(type: "int", nullable: false),
                    CoefConge = table.Column<int>(type: "int", nullable: false),
                    NatureId = table.Column<int>(type: "int", nullable: false),
                    SalaireBase = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    TypeContratId = table.Column<int>(type: "int", nullable: false),
                    EnActivite = table.Column<bool>(type: "bit", nullable: false),
                    SoumisImpot = table.Column<bool>(type: "bit", nullable: false),
                    ParentCharge = table.Column<bool>(type: "bit", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModeReglementId = table.Column<int>(type: "int", nullable: false),
                    MatriculeAssuranceSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NbreParentAcharge = table.Column<int>(type: "int", nullable: false),
                    NumeroCNSS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCIN = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDebutContrat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFinContrat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSortie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargePatronaleId = table.Column<int>(type: "int", nullable: false),
                    DateDebut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEchange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aarrondie = table.Column<bool>(type: "bit", nullable: false),
                    ComplementSalaire = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    STC = table.Column<bool>(type: "bit", nullable: false),
                    NumeroSession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NonRegle = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnels", x => new { x.PersonnelKey, x.SessionKey });
                    table.ForeignKey(
                        name: "FK_Personnels_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnels_ChargePatronales_ChargePatronaleId",
                        column: x => x.ChargePatronaleId,
                        principalTable: "ChargePatronales",
                        principalColumn: "ChargePatronaleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnels_Echelons_EchelonId",
                        column: x => x.EchelonId,
                        principalTable: "Echelons",
                        principalColumn: "EchelonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnels_ModeReglements_ModeReglementId",
                        column: x => x.ModeReglementId,
                        principalTable: "ModeReglements",
                        principalColumn: "ModeReglementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnels_Natures_NatureId",
                        column: x => x.NatureId,
                        principalTable: "Natures",
                        principalColumn: "NatureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnels_Organigrammes_OrganigrammeId",
                        column: x => x.OrganigrammeId,
                        principalTable: "Organigrammes",
                        principalColumn: "OrganigrammeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnels_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "QualificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnels_Regimes_RegimeId",
                        column: x => x.RegimeId,
                        principalTable: "Regimes",
                        principalColumn: "RegimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnels_Sessions_SessionKey",
                        column: x => x.SessionKey,
                        principalTable: "Sessions",
                        principalColumn: "SessionKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnels_TypeContrats_TypeContratId",
                        column: x => x.TypeContratId,
                        principalTable: "TypeContrats",
                        principalColumn: "TypeContratId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrimePersonnels",
                columns: table => new
                {
                    PrimePersonnelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelKey = table.Column<int>(type: "int", nullable: false),
                    TypePrimeId = table.Column<int>(type: "int", nullable: false),
                    montant = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    PersonnelKey1 = table.Column<int>(type: "int", nullable: true),
                    PersonnelSessionKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimePersonnels", x => x.PrimePersonnelId);
                    table.ForeignKey(
                        name: "FK_PrimePersonnels_Personnels_PersonnelKey1_PersonnelSessionKey",
                        columns: x => new { x.PersonnelKey1, x.PersonnelSessionKey },
                        principalTable: "Personnels",
                        principalColumns: new[] { "PersonnelKey", "SessionKey" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrimePersonnels_TypePrimes_TypePrimeId",
                        column: x => x.TypePrimeId,
                        principalTable: "TypePrimes",
                        principalColumn: "TypePrimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_CategorieId",
                table: "Personnels",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_ChargePatronaleId",
                table: "Personnels",
                column: "ChargePatronaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_EchelonId",
                table: "Personnels",
                column: "EchelonId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_ModeReglementId",
                table: "Personnels",
                column: "ModeReglementId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_NatureId",
                table: "Personnels",
                column: "NatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_OrganigrammeId",
                table: "Personnels",
                column: "OrganigrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_QualificationId",
                table: "Personnels",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_RegimeId",
                table: "Personnels",
                column: "RegimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_SessionKey",
                table: "Personnels",
                column: "SessionKey");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_TypeContratId",
                table: "Personnels",
                column: "TypeContratId");

            migrationBuilder.CreateIndex(
                name: "IX_PrimePersonnels_PersonnelKey1_PersonnelSessionKey",
                table: "PrimePersonnels",
                columns: new[] { "PersonnelKey1", "PersonnelSessionKey" });

            migrationBuilder.CreateIndex(
                name: "IX_PrimePersonnels_TypePrimeId",
                table: "PrimePersonnels",
                column: "TypePrimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_TypePaiesId",
                table: "Sessions",
                column: "TypePaiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrimePersonnels");

            migrationBuilder.DropTable(
                name: "Personnels");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropColumn(
                name: "Libelle",
                table: "TypePaie");
        }
    }
}
