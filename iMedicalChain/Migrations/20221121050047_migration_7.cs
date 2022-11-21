using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iMedicalChain.Migrations
{
    /// <inheritdoc />
    public partial class migration7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Heigt",
                table: "SickSheets");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SickSheets");

            migrationBuilder.DropColumn(
                name: "RegistrDay",
                table: "SickSheets");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "SickSheets");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DoctorsId",
                table: "SickSheets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "SickSheets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SickHistoryId",
                table: "SickSheets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SickSheets_DoctorsId",
                table: "SickSheets",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_SickSheets_PatientId",
                table: "SickSheets",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_SickSheets_SickHistoryId",
                table: "SickSheets",
                column: "SickHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SickSheets_Patients_PatientId",
                table: "SickSheets",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SickSheets_SickHistories_SickHistoryId",
                table: "SickSheets",
                column: "SickHistoryId",
                principalTable: "SickHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SickSheets_Users_DoctorsId",
                table: "SickSheets",
                column: "DoctorsId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SickSheets_Patients_PatientId",
                table: "SickSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_SickSheets_SickHistories_SickHistoryId",
                table: "SickSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_SickSheets_Users_DoctorsId",
                table: "SickSheets");

            migrationBuilder.DropIndex(
                name: "IX_SickSheets_DoctorsId",
                table: "SickSheets");

            migrationBuilder.DropIndex(
                name: "IX_SickSheets_PatientId",
                table: "SickSheets");

            migrationBuilder.DropIndex(
                name: "IX_SickSheets_SickHistoryId",
                table: "SickSheets");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DoctorsId",
                table: "SickSheets");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "SickSheets");

            migrationBuilder.DropColumn(
                name: "SickHistoryId",
                table: "SickSheets");

            migrationBuilder.AddColumn<decimal>(
                name: "Heigt",
                table: "SickSheets",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SickSheets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrDay",
                table: "SickSheets",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "SickSheets",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
