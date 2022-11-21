using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iMedicalChain.Migrations
{
    /// <inheritdoc />
    public partial class migration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirhtDay",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PINFL",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasspordSeriaAndNumber",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BirhtDay",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PINFL",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasspordSeriaAndNumber",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Users",
                newName: "Username");
        }
    }
}
