using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportMonitorBlazor.Api.Migrations
{
    public partial class DiskSpace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiskSpace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TmsId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreespacePercentMinimum = table.Column<int>(type: "int", nullable: false),
                    FrespaceMinimumBytes = table.Column<int>(type: "int", nullable: false),
                    Actualsize = table.Column<int>(type: "int", nullable: false),
                    MaxSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiskSpace", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DiskSpace",
                columns: new[] { "Id", "Actualsize", "FreespacePercentMinimum", "FrespaceMinimumBytes", "MaxSize", "Name", "TmsId", "Type" },
                values: new object[] { 1, 9999, 5, 5000, 10000, "E", 2, "Local Disk" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiskSpace");
        }
    }
}
