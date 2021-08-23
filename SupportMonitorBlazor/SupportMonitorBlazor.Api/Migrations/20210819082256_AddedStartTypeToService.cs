using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportMonitorBlazor.Api.Migrations
{
    public partial class AddedStartTypeToService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StartType",
                table: "TMS_Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TMS_Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "RunningSince",
                value: new DateTime(2021, 8, 19, 10, 22, 54, 875, DateTimeKind.Local).AddTicks(9825));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartType",
                table: "TMS_Services");

            migrationBuilder.UpdateData(
                table: "TMS_Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "RunningSince",
                value: new DateTime(2021, 8, 18, 14, 20, 22, 359, DateTimeKind.Local).AddTicks(5643));
        }
    }
}
