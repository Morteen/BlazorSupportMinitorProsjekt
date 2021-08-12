using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportMonitorBlazor.Api.Migrations
{
    public partial class TmsProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TmsProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TmsId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmsProperties", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TmsProperties",
                columns: new[] { "Id", "Name", "TmsId", "Value" },
                values: new object[] { 1, "TransFleet WebApi", 6, "http://tms.gaus.no:31003/docs/" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TmsProperties");
        }
    }
}
