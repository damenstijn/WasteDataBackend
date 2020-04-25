using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WasteData.Infra.Migrations
{
    public partial class Added_Device : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConnectionName",
                schema: "dbo",
                table: "DownloadTest",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "dbo",
                table: "DownloadTest",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DeviceId",
                schema: "dbo",
                table: "DownloadTest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                schema: "dbo",
                table: "DownloadTest",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Device",
                schema: "dbo",
                columns: table => new
                {
                    DeviceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceGuid = table.Column<Guid>(nullable: false),
                    DeviceName = table.Column<string>(nullable: false, maxLength:1000),
                    OsId = table.Column<int>(nullable: false),
                    OsVersion = table.Column<string>(nullable: false, maxLength:1000)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.DeviceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DownloadTest_DeviceId",
                schema: "dbo",
                table: "DownloadTest",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadTest_TotalBytesDownloaded",
                schema: "dbo",
                table: "DownloadTest",
                column: "TotalBytesDownloaded");

            migrationBuilder.CreateIndex(
                name: "IX_Device_DeviceGuid",
                schema: "dbo",
                table: "Device",
                column: "DeviceGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_DownloadTest_Device_DeviceId",
                schema: "dbo",
                table: "DownloadTest",
                column: "DeviceId",
                principalSchema: "dbo",
                principalTable: "Device",
                principalColumn: "DeviceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DownloadTest_Device_DeviceId",
                schema: "dbo",
                table: "DownloadTest");

            migrationBuilder.DropTable(
                name: "Device",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_DownloadTest_DeviceId",
                schema: "dbo",
                table: "DownloadTest");

            migrationBuilder.DropIndex(
                name: "IX_DownloadTest_TotalBytesDownloaded",
                schema: "dbo",
                table: "DownloadTest");

            migrationBuilder.DropColumn(
                name: "ConnectionName",
                schema: "dbo",
                table: "DownloadTest");

            migrationBuilder.DropColumn(
                name: "Country",
                schema: "dbo",
                table: "DownloadTest");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                schema: "dbo",
                table: "DownloadTest");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                schema: "dbo",
                table: "DownloadTest");
        }
    }
}
