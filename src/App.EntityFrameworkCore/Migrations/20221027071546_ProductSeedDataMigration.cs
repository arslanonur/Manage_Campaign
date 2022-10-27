using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class ProductSeedDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 99999);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Brand", "CategoryId", "CategoryName", "Price", "ProductCode", "ProductGroups", "ProductName", "Quatity" },
                values: new object[] { 99999, "MERİNOS", 1, "ev-dekorasyon", 100.0, "HALI-001", "ev-dekorasyon,halilarda-kampanya", "Merinos 001 Halı", 1 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Brand", "CategoryId", "CategoryName", "Price", "ProductCode", "ProductGroups", "ProductName", "Quatity" },
                values: new object[] { 99998, "IKEA", 1, "ev-dekorasyon", 150.0, "SHP-001", "ev-dekorasyon,250TL-Uzeri-Ev-Dekorasyon-25TL-Indirim,Sehpa", "Ikea 001 Sehpa", 1 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Brand", "CategoryId", "CategoryName", "Price", "ProductCode", "ProductGroups", "ProductName", "Quatity" },
                values: new object[] { 99997, "APPLE", 1, "cep-telefonu", 10000.0, "APL-001", "cep-telefonu,iphone", "Iphone 12 64GB", 2 });
        }
    }
}
