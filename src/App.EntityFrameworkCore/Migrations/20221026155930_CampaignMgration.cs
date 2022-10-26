using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class CampaignMgration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CampaignLevelName",
                table: "Campaign",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CampaignLevelName",
                table: "Campaign");
        }
    }
}
