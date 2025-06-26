using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapsulaDoTempo.Migrations
{
    /// <inheritdoc />
    public partial class addnovosatributosacapsula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateToSend",
                table: "Capsula",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateToSend",
                table: "Capsula");
        }
    }
}
