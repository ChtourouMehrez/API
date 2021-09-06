using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ChargePatronale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChargePatronales",
                columns: table => new
                {
                    ChargePatronaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeChargePatronale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Taux = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    CodeExpoloitation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargePatronales", x => x.ChargePatronaleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChargePatronales");
        }
    }
}
