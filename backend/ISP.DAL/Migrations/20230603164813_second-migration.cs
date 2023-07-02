using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ISP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "groupId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsManager = table.Column<bool>(type: "bit", nullable: false),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: false),
                    ReadClients = table.Column<bool>(type: "bit", nullable: false),
                    ReadWriteClients = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "IsAdmin", "IsEmployee", "IsManager", "Name", "ReadClients", "ReadWriteClients" },
                values: new object[,]
                {
                    { 1, true, false, false, "Admin", false, false },
                    { 2, false, false, true, "Manager", false, false },
                    { 3, false, true, false, "Employee", false, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_groupId",
                table: "AspNetUsers",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Groups_groupId",
                table: "AspNetUsers",
                column: "groupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groups_groupId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_groupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "groupId",
                table: "AspNetUsers");
        }
    }
}
