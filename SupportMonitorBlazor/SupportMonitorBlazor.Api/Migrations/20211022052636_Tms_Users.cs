using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportMonitorBlazor.Api.Migrations
{
    public partial class Tms_Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TmsUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmsUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TMS_Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "RunningSince",
                value: new DateTime(2021, 10, 22, 7, 26, 35, 734, DateTimeKind.Local).AddTicks(9240));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TmsUsers");

            migrationBuilder.UpdateData(
                table: "TMS_Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "RunningSince",
                value: new DateTime(2021, 8, 19, 10, 22, 54, 875, DateTimeKind.Local).AddTicks(9825));
        }
    }
}
