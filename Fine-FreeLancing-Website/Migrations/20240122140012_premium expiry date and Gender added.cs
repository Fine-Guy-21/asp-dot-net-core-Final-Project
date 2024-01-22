using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FineFreeLancingWebsite.Migrations
{
    /// <inheritdoc />
    public partial class premiumexpirydateandGenderadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PremiumExpirationDate",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PremiumExpirationDate",
                table: "AspNetUsers");
        }
    }
}
