using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class eigthmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ClientId",
                table: "Offers",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Clients_ClientId",
                table: "Offers",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Clients_ClientId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_ClientId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Offers");
        }
    }
}
