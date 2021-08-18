using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportMonitorBlazor.Api.Migrations
{
    public partial class AutoKeyForTMS_services : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TMS_Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TMS_Id = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RunningSince = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMS_Services", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TMS_Services",
                columns: new[] { "Id", "DisplayName", "Name", "RunningSince", "Status", "TMS_Id" },
                values: new object[] { 1, "Test", "Test", new DateTime(2021, 8, 18, 14, 20, 22, 359, DateTimeKind.Local).AddTicks(5643), null, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TMS_Services");
        }
    }
}
