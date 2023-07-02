using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class sixthmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "branchId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernarateId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumberOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumberTwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumberOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumberTwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_AspNetUsers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Branches_Governarates_GovernarateId",
                        column: x => x.GovernarateId,
                        principalTable: "Governarates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Centrals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernarateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centrals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Centrals_Governarates_GovernarateId",
                        column: x => x.GovernarateId,
                        principalTable: "Governarates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "InternetServiceProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetServiceProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bundles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BundleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BuyingPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bundles_InternetServiceProviders_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "InternetServiceProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernarateCode = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    BundleId = table.Column<int>(type: "int", nullable: false),
                    CentralId = table.Column<int>(type: "int", nullable: false),
                    IpPackage = table.Column<int>(type: "int", nullable: true),
                    Contractdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mobile1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    RouterSerial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: true),
                    PortSlot = table.Column<int>(type: "int", nullable: true),
                    PortBlock = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VPI = table.Column<int>(type: "int", nullable: true),
                    VCI = table.Column<int>(type: "int", nullable: true),
                    OrderWorkNumber = table.Column<int>(type: "int", nullable: true),
                    Orderworkdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrePaid = table.Column<double>(type: "float", nullable: false),
                    InstallationFee = table.Column<double>(type: "float", nullable: false),
                    ContractFee = table.Column<double>(type: "float", nullable: false),
                    SlotNum = table.Column<int>(type: "int", nullable: true),
                    BlockNum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Bundles_BundleId",
                        column: x => x.BundleId,
                        principalTable: "Bundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Centrals_CentralId",
                        column: x => x.CentralId,
                        principalTable: "Centrals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Governarates_GovernarateCode",
                        column: x => x.GovernarateCode,
                        principalTable: "Governarates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_InternetServiceProviders_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "InternetServiceProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_branchId",
                table: "AspNetUsers",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_GovernarateId",
                table: "Branches",
                column: "GovernarateId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ManagerId",
                table: "Branches",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bundles_ProviderID",
                table: "Bundles",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Centrals_GovernarateId",
                table: "Centrals",
                column: "GovernarateId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BranchId",
                table: "Clients",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BundleId",
                table: "Clients",
                column: "BundleId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CentralId",
                table: "Clients",
                column: "CentralId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_GovernarateCode",
                table: "Clients",
                column: "GovernarateCode");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ProviderId",
                table: "Clients",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Branches_branchId",
                table: "AspNetUsers",
                column: "branchId",
                principalTable: "Branches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Branches_branchId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Bundles");

            migrationBuilder.DropTable(
                name: "Centrals");

            migrationBuilder.DropTable(
                name: "InternetServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_branchId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "branchId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "status",
                table: "AspNetUsers");
        }
    }
}
