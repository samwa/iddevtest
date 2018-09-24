using Microsoft.EntityFrameworkCore.Migrations;

namespace iddevtest.Migrations
{
    public partial class NullDisadvantageField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<int>(
                name: "SEIFADisadvantage2016",
                table: "Lgas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SEIFADisadvantage2011",
                table: "Lgas",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SEIFADisadvantage2016",
                table: "Lgas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SEIFADisadvantage2011",
                table: "Lgas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
