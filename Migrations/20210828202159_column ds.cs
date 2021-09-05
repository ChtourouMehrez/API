using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class columnds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Salaire",
                table: "GrilleSalaires",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Salaire",
                table: "GrilleSalaires",
                type: "decimal(18,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
