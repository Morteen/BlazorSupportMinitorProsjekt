using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportMonitorBlazor.Api.Migrations
{
    public partial class CriticalErrorsRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 1,
                column: "CriticalErrors",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 9,
                column: "CriticalErrors",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 14,
                column: "CriticalErrors",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 1,
                column: "CriticalErrors",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 9,
                column: "CriticalErrors",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 14,
                column: "CriticalErrors",
                value: 0);
        }
    }
}
