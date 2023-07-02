using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class toffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsThereDiscount",
                table: "Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RouterCost",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsThereDiscount",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "RouterCost",
                table: "Offers");
        }
    }
}
