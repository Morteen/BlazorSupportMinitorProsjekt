using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportMonitorBlazor.Api.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BlazorTMS",
                columns: new[] { "TmsId", "Country", "CriticalErrors", "Name", "TmsCategory" },
                values: new object[] { 2, "Sverige", 0, "Foria", "Tdxlog" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 2);
        }
    }
}
