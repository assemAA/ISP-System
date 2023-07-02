using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class offers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FineInFirstYear = table.Column<int>(type: "int", nullable: false),
                    PeriodForCancelOffer = table.Column<int>(type: "int", nullable: false),
                    AbilityToLowOrRaise = table.Column<bool>(type: "bit", nullable: false),
                    AmountOfOfferMonths = table.Column<int>(type: "int", nullable: false),
                    AmountOfFreeMonths = table.Column<int>(type: "int", nullable: false),
                    FreeMonthsFirst = table.Column<bool>(type: "bit", nullable: false),
                    CombinedBill = table.Column<bool>(type: "bit", nullable: false),
                    AmountOfDiscount = table.Column<int>(type: "int", nullable: false),
                    IsIncludeRouter = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchOffer",
                columns: table => new
                {
                    BranchesId = table.Column<int>(type: "int", nullable: false),
                    OffersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOffer", x => new { x.BranchesId, x.OffersId });
                    table.ForeignKey(
                        name: "FK_BranchOffer_Branches_BranchesId",
                        column: x => x.BranchesId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchOffer_Offers_OffersId",
                        column: x => x.OffersId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchOffer_OffersId",
                table: "BranchOffer",
                column: "OffersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchOffer");

            migrationBuilder.DropTable(
                name: "Offers");
        }
    }
}
