using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FineFreeLancingWebsite.Migrations
{
    /// <inheritdoc />
    public partial class JobUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "JobPostedtime",
                table: "Jobs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobPostedtime",
                table: "Jobs");
        }
    }
}
