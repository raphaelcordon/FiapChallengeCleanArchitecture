using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Packages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PackageReceived",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "GUID", nullable: false),
                    DonorId = table.Column<Guid>(type: "GUID", nullable: false),
                    PackageCreation = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageReceived", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageReceived_Donor_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageSent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "GUID", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "GUID", nullable: false),
                    PackageCreation = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageSent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageSent_Receiver_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Receiver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageReceivedFood",
                columns: table => new
                {
                    PackageReceivedId = table.Column<Guid>(type: "GUID", nullable: false),
                    FoodId = table.Column<Guid>(type: "GUID", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageReceivedFood", x => new { x.PackageReceivedId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_PackageReceivedFood_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageReceivedFood_PackageReceived_PackageReceivedId",
                        column: x => x.PackageReceivedId,
                        principalTable: "PackageReceived",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageSentFood",
                columns: table => new
                {
                    PackageSentId = table.Column<Guid>(type: "GUID", nullable: false),
                    FoodId = table.Column<Guid>(type: "GUID", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageSentFood", x => new { x.PackageSentId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_PackageSentFood_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageSentFood_PackageSent_PackageSentId",
                        column: x => x.PackageSentId,
                        principalTable: "PackageSent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageReceived_DonorId",
                table: "PackageReceived",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageReceivedFood_FoodId",
                table: "PackageReceivedFood",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageSent_ReceiverId",
                table: "PackageSent",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageSentFood_FoodId",
                table: "PackageSentFood",
                column: "FoodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageReceivedFood");

            migrationBuilder.DropTable(
                name: "PackageSentFood");

            migrationBuilder.DropTable(
                name: "PackageReceived");

            migrationBuilder.DropTable(
                name: "PackageSent");
        }
    }
}
