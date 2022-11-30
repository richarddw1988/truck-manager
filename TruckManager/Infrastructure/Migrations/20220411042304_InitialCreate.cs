using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckManager.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MODELO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    ATIVO = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MODELO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TRUCK",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    ANO_FABRICACAO = table.Column<int>(type: "INT", nullable: false),
                    ANO_MODELO = table.Column<int>(type: "INT", nullable: false),
                    ID_MODELO = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRUCK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRUCK_MODELO_ID_MODELO",
                        column: x => x.ID_MODELO,
                        principalTable: "MODELO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TRUCK_ID_MODELO",
                table: "TRUCK",
                column: "ID_MODELO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRUCK");

            migrationBuilder.DropTable(
                name: "MODELO");
        }
    }
}
