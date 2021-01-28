using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "PhotoPath", "Price" },
                values: new object[] { 1, "Journal 3 brims with every page ever seen on the show plus all-new pages with monsters and secrets, notes from Dipper and Mabel, and the Author's full story.", "Gravity Falls: Journal 3", null, 10.199999999999999 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "PhotoPath", "Price" },
                values: new object[] { 2, "2020 themed christmas ornament.", "2020 Christmas Ornament", null, 4.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
