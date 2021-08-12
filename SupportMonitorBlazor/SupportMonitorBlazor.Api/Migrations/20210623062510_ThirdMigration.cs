using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportMonitorBlazor.Api.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BlazorTMS",
                columns: new[] { "TmsId", "Country", "CriticalErrors", "Name", "TmsCategory" },
                values: new object[,]
                {
                    { 5, "Felles nordisk", 0, "DSV", "TransFleet" },
                    { 6, "Norsk", 0, "Gausdal Skurlag", "TransFleet" },
                    { 7, "Norsk", 0, "Brødrene Dahl", "TransFleet" },
                    { 8, "Norsk", 0, "Alvdal Skurlag", "TransFleet" },
                    { 9, "Norsk", 1, "Østfold Olje Ragnar Larsen & Sønner", "TransFleet" },
                    { 10, "Norsk", 0, "Toll", "TransFleet" },
                    { 11, "Sverige", 0, "Wiklunds", "Tdxlog" },
                    { 12, "Sverige", 0, "LBC Logistik", "Tdxlog" },
                    { 13, "Sverige", 0, "LBC Tingsryd", "Tdxlog" },
                    { 14, "Sverige", 1, "Örnfrakt", "Tdxlog" },
                    { 15, "Sverige", 0, "Fraktkedjan Anläggning AB", "Tdxlog" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "BlazorTMS",
                keyColumn: "TmsId",
                keyValue: 15);
        }
    }
}
