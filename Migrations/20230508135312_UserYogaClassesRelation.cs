using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaReservationAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserYogaClassesRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserYogaClass",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    YogaClassesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserYogaClass", x => new { x.UsersId, x.YogaClassesId });
                    table.ForeignKey(
                        name: "FK_UserYogaClass_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserYogaClass_YogaClasses_YogaClassesId",
                        column: x => x.YogaClassesId,
                        principalTable: "YogaClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserYogaClass_YogaClassesId",
                table: "UserYogaClass",
                column: "YogaClassesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserYogaClass");
        }
    }
}
