using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class fourthmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groups_groupId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Groups",
                newName: "groupRole");

            migrationBuilder.RenameColumn(
                name: "groupId",
                table: "AspNetUsers",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_groupId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Groups_GroupId",
                table: "AspNetUsers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groups_GroupId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "groupRole",
                table: "Groups",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "AspNetUsers",
                newName: "groupId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_GroupId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_groupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Groups_groupId",
                table: "AspNetUsers",
                column: "groupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
