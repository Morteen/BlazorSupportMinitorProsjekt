using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportMonitorBlazor.Api.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BlazorTMS",
                columns: new[] { "TmsId", "Country", "CriticalErrors", "Name", "TmsCategory" },
                values: new object[] { 3, "Sverige", 0, "LBC Logistik", "Tdxlog" });

            migrationBuilder.InsertData(
                table: "BlazorTMS",
                columns: new[] { "TmsId", "Country", "CriticalErrors", "Name", "TmsCategory" },
                values: new object[] { 4, "Finland", 0, "Gigantti OY", "TransFleet" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 4);
        }
    }
}
