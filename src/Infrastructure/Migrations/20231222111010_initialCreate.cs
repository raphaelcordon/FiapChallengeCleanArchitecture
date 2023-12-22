using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "GUID", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsCompany = table.Column<bool>(type: "BOOL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receiver",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "GUID", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsCompany = table.Column<bool>(type: "BOOL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receiver", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donor");

            migrationBuilder.DropTable(
                name: "Receiver");
        }
    }
}
