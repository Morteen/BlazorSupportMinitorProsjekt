using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportMonitorBlazor.Api.Migrations
{
    public partial class SystemValusAndTmsError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BlazorTMS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SystemValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TmsErrors",
                columns: table => new
                {
                    TmsErrorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TMSid = table.Column<int>(type: "int", nullable: false),
                    ErrorInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredAction = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmsErrors", x => x.TmsErrorId);
                });

            migrationBuilder.InsertData(
                table: "SystemValues",
                columns: new[] { "Id", "SystemName", "SystemValue" },
                values: new object[,]
                {
                    { 3, "PROGRAM_RUNNING", "CRASH" },
                    { 1, "NETWORK", "OK" },
                    { 2, "MOBILE", "OK" }
                });

            migrationBuilder.InsertData(
                table: "TmsErrors",
                columns: new[] { "TmsErrorId", "ErrorDetail", "ErrorInformation", "RequiredAction", "SystemFunction", "TMSid" },
                values: new object[,]
                {
                    { 2, "TdxExt feil detektert  2021-06-22 07:05", "Fatal Program feil", "Hent ut detalj logger fra Ext-en og send til utvikler", "ImportEksport datafeil", 2 },
                    { 1, "TdxExt har stoppet 2021-06-22 07:05", "ImportEksport har stoppet", "Logg inn på Wicklunds server og restart TdxLogContoller tjenestene", "ImportEksport", 11 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemValues");

            migrationBuilder.DropTable(
                name: "TmsErrors");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BlazorTMS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
