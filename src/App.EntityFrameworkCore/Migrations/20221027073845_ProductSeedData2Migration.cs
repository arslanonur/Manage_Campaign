using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class ProductSeedData2Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Brand", "CategoryId", "CategoryName", "Price", "ProductCode", "ProductGroups", "ProductName", "Quatity" },
                values: new object[] { 1, "MERİNOS", 1, "ev-dekorasyon", 100.0, "HALI-001", "ev-dekorasyon,halilarda-kampanya", "Merinos 001 Halı", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
