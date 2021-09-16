using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class foreignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grilles_Categories_CategorieId",
                table: "Grilles");

            migrationBuilder.DropForeignKey(
                name: "FK_Grilles_Echelons_EchelonId",
                table: "Grilles");

            migrationBuilder.DropForeignKey(
                name: "FK_Grilles_Qualifications_QualificationId",
                table: "Grilles");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Categories_CategorieId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_ChargePatronales_ChargePatronaleId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Echelons_EchelonId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_ModeReglements_ModeReglementId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Organigrammes_OrganigrammeId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Qualifications_QualificationId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Regimes_RegimeId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Sessions_SessionKey",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_TypeContrats_TypeContratId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_PrimePersonnels_TypePrimes_TypePrimeId",
                table: "PrimePersonnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_TypePaie_TypePaiesId",
                table: "Sessions");

            migrationBuilder.AddForeignKey(
                name: "FK_Grilles_Categories_CategorieId",
                table: "Grilles",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grilles_Echelons_EchelonId",
                table: "Grilles",
                column: "EchelonId",
                principalTable: "Echelons",
                principalColumn: "EchelonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grilles_Qualifications_QualificationId",
                table: "Grilles",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "QualificationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Categories_CategorieId",
                table: "Personnels",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_ChargePatronales_ChargePatronaleId",
                table: "Personnels",
                column: "ChargePatronaleId",
                principalTable: "ChargePatronales",
                principalColumn: "ChargePatronaleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Echelons_EchelonId",
                table: "Personnels",
                column: "EchelonId",
                principalTable: "Echelons",
                principalColumn: "EchelonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_ModeReglements_ModeReglementId",
                table: "Personnels",
                column: "ModeReglementId",
                principalTable: "ModeReglements",
                principalColumn: "ModeReglementId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Organigrammes_OrganigrammeId",
                table: "Personnels",
                column: "OrganigrammeId",
                principalTable: "Organigrammes",
                principalColumn: "OrganigrammeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Qualifications_QualificationId",
                table: "Personnels",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "QualificationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Regimes_RegimeId",
                table: "Personnels",
                column: "RegimeId",
                principalTable: "Regimes",
                principalColumn: "RegimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Sessions_SessionKey",
                table: "Personnels",
                column: "SessionKey",
                principalTable: "Sessions",
                principalColumn: "SessionKey",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_TypeContrats_TypeContratId",
                table: "Personnels",
                column: "TypeContratId",
                principalTable: "TypeContrats",
                principalColumn: "TypeContratId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrimePersonnels_TypePrimes_TypePrimeId",
                table: "PrimePersonnels",
                column: "TypePrimeId",
                principalTable: "TypePrimes",
                principalColumn: "TypePrimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_TypePaie_TypePaiesId",
                table: "Sessions",
                column: "TypePaiesId",
                principalTable: "TypePaie",
                principalColumn: "TypePaiesId",
                onDelete: ReferentialAction.Restrict);
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
                name: "FK_Grilles_Qualifications_QualificationId",
                table: "Grilles");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Categories_CategorieId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_ChargePatronales_ChargePatronaleId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Echelons_EchelonId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_ModeReglements_ModeReglementId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Organigrammes_OrganigrammeId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Qualifications_QualificationId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Regimes_RegimeId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Sessions_SessionKey",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_TypeContrats_TypeContratId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_PrimePersonnels_TypePrimes_TypePrimeId",
                table: "PrimePersonnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_TypePaie_TypePaiesId",
                table: "Sessions");

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
                name: "FK_Grilles_Qualifications_QualificationId",
                table: "Grilles",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "QualificationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Categories_CategorieId",
                table: "Personnels",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_ChargePatronales_ChargePatronaleId",
                table: "Personnels",
                column: "ChargePatronaleId",
                principalTable: "ChargePatronales",
                principalColumn: "ChargePatronaleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Echelons_EchelonId",
                table: "Personnels",
                column: "EchelonId",
                principalTable: "Echelons",
                principalColumn: "EchelonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_ModeReglements_ModeReglementId",
                table: "Personnels",
                column: "ModeReglementId",
                principalTable: "ModeReglements",
                principalColumn: "ModeReglementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Organigrammes_OrganigrammeId",
                table: "Personnels",
                column: "OrganigrammeId",
                principalTable: "Organigrammes",
                principalColumn: "OrganigrammeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Qualifications_QualificationId",
                table: "Personnels",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "QualificationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Regimes_RegimeId",
                table: "Personnels",
                column: "RegimeId",
                principalTable: "Regimes",
                principalColumn: "RegimeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Sessions_SessionKey",
                table: "Personnels",
                column: "SessionKey",
                principalTable: "Sessions",
                principalColumn: "SessionKey",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_TypeContrats_TypeContratId",
                table: "Personnels",
                column: "TypeContratId",
                principalTable: "TypeContrats",
                principalColumn: "TypeContratId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrimePersonnels_TypePrimes_TypePrimeId",
                table: "PrimePersonnels",
                column: "TypePrimeId",
                principalTable: "TypePrimes",
                principalColumn: "TypePrimeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_TypePaie_TypePaiesId",
                table: "Sessions",
                column: "TypePaiesId",
                principalTable: "TypePaie",
                principalColumn: "TypePaiesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
