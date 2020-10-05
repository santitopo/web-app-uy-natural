using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class tpointLodging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TPointId",
                table: "Lodgings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lodgings_TPointId",
                table: "Lodgings",
                column: "TPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lodgings_TouristicPoints_TPointId",
                table: "Lodgings",
                column: "TPointId",
                principalTable: "TouristicPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lodgings_TouristicPoints_TPointId",
                table: "Lodgings");

            migrationBuilder.DropIndex(
                name: "IX_Lodgings_TPointId",
                table: "Lodgings");

            migrationBuilder.DropColumn(
                name: "TPointId",
                table: "Lodgings");
        }
    }
}
