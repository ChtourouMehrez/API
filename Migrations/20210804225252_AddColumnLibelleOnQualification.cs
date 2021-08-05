using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddColumnLibelleOnQualification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeQualification",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Libelle",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeQualification",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "Libelle",
                table: "Qualifications");
        }
    }
}
