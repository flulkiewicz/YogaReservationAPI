using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaReservationAPI.Migrations
{
    /// <inheritdoc />
    public partial class LocationDBset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YogaClasses_Location_LocationId",
                table: "YogaClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_YogaClasses_Locations_LocationId",
                table: "YogaClasses",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YogaClasses_Locations_LocationId",
                table: "YogaClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_YogaClasses_Location_LocationId",
                table: "YogaClasses",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");
        }
    }
}
