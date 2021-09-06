using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class TypeCNSS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeCNSSs",
                columns: table => new
                {
                    TypeCNSSId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Taux = table.Column<decimal>(type: "decimal(18,3)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCNSSs", x => x.TypeCNSSId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeCNSSs");
        }
    }
}
