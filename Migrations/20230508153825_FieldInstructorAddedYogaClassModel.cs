using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaReservationAPI.Migrations
{
    /// <inheritdoc />
    public partial class FieldInstructorAddedYogaClassModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InstructorStatus",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstructorStatus",
                table: "Users");
        }
    }
}
