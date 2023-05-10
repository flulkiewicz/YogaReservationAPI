using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaReservationAPI.Migrations
{
    /// <inheritdoc />
    public partial class FurtherLocationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YogaClasses_Locations_LocationId",
                table: "YogaClasses");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "YogaClasses",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address" },
                values: new object[] { 1, "To be confirmed" });

            migrationBuilder.AddForeignKey(
                name: "FK_YogaClasses_Locations_LocationId",
                table: "YogaClasses",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YogaClasses_Locations_LocationId",
                table: "YogaClasses");

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "YogaClasses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_YogaClasses_Locations_LocationId",
                table: "YogaClasses",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
