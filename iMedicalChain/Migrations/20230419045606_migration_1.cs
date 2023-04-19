using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace iMedicalChain.Migrations
{
    public partial class migration_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: false),
                    timestamp = table.Column<string>(nullable: true),
                    data = table.Column<string>(nullable: true),
                    hash = table.Column<string>(nullable: true),
                    nonce = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChainUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Longituda = table.Column<long>(nullable: false),
                    Laptituda = table.Column<long>(nullable: false),
                    LastSync = table.Column<long>(nullable: false),
                    AllBlock = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChainUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirhtDay = table.Column<DateTime>(nullable: false),
                    Adress = table.Column<string>(nullable: true),
                    PasspordSeriaAndNumber = table.Column<string>(nullable: true),
                    PINFL = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SickHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: false),
                    HospitalName = table.Column<string>(nullable: true),
                    TimeToCome = table.Column<DateTime>(nullable: false),
                    SickDefinedTime = table.Column<DateTime>(nullable: false),
                    GetHospitalName = table.Column<string>(nullable: true),
                    DiagnozGetHospitalName = table.Column<string>(nullable: true),
                    DiagnozinReception = table.Column<string>(nullable: true),
                    ClinicalDiagnoz = table.Column<string>(nullable: true),
                    FinalDiagnoz = table.Column<string>(nullable: true),
                    MainDiagnoz = table.Column<string>(nullable: true),
                    MainSickResult = table.Column<string>(nullable: true),
                    Complaints = table.Column<string>(nullable: true),
                    AnamnesisMorbi = table.Column<string>(nullable: true),
                    AnamnesisVitae = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SickHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirhtDay = table.Column<DateTime>(nullable: false),
                    Adress = table.Column<string>(nullable: true),
                    PasspordSeriaAndNumber = table.Column<string>(nullable: true),
                    PINFL = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SickSheets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: false),
                    DoctorsId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    SickHistoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SickSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SickSheets_Users_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SickSheets_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SickSheets_SickHistories_SickHistoryId",
                        column: x => x.SickHistoryId,
                        principalTable: "SickHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "ChainUsers");

            migrationBuilder.DropTable(
                name: "SickSheets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "SickHistories");
        }
    }
}
