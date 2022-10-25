using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class ProductMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Product",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductGroups",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quatity",
                table: "Product",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductGroups",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Quatity",
                table: "Product");
        }
    }
}
