using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportMonitorBlazor.Api.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlazorTMS",
                columns: table => new
                {
                    TmsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TmsCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KriticalErrors = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlazorTMS", x => x.TmsId);
                });

            migrationBuilder.InsertData(
                table: "BlazorTMS",
                columns: new[] { "TmsId", "Country", "CriticalErrors", "Name", "TmsCategory" },
                values: new object[] { 1, "Norge", 1, "Elkjøp", "TransFleet" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlazorTMS");
        }
    }
}
