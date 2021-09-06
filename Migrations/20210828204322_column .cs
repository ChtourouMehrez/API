using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salaire",
                table: "GrilleSalaires");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Salaire",
                table: "GrilleSalaires",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
