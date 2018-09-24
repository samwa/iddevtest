using Microsoft.EntityFrameworkCore.Migrations;

namespace iddevtest.Migrations
{
    public partial class SampleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lgas",
                columns: new[] { "LgaId", "Place", "SEIFADisadvantage2011", "SEIFADisadvantage2016", "State" },
                values: new object[] { 1, "Albury (C)", 979, 971, "New South Wales" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lgas",
                keyColumn: "LgaId",
                keyValue: 1);
        }
    }
}
