using Microsoft.EntityFrameworkCore.Migrations;

namespace DailerApp.Data.Migrations
{
    public partial class userexp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Expierence",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expierence",
                table: "AspNetUsers");
        }
    }
}
