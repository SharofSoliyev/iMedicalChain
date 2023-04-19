using Microsoft.EntityFrameworkCore.Migrations;

namespace iMedicalChain.Migrations
{
    public partial class migration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Longituda",
                table: "ChainUsers",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<float>(
                name: "Laptituda",
                table: "ChainUsers",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Longituda",
                table: "ChainUsers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<long>(
                name: "Laptituda",
                table: "ChainUsers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
