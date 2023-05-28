using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZucoBackend.Migrations
{
    public partial class ModifyImaeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "ImageModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageModels_ReportId",
                table: "ImageModels",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageModels_Reports_ReportId",
                table: "ImageModels",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageModels_Reports_ReportId",
                table: "ImageModels");

            migrationBuilder.DropIndex(
                name: "IX_ImageModels_ReportId",
                table: "ImageModels");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "ImageModels");
        }
    }
}
