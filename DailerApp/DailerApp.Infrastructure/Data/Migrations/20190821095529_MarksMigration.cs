using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DailerApp.Data.Migrations
{
    public partial class MarksMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: true),
                    TraitId = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marks_Traits_TraitId",
                        column: x => x.TraitId,
                        principalTable: "Traits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Marks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Traits",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 1, "Take care of it", "Family" });

            migrationBuilder.InsertData(
                table: "Traits",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 2, "Spend time with them", "Friends" });

            migrationBuilder.InsertData(
                table: "Traits",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 3, "Don't lost it", "Health" });

            migrationBuilder.InsertData(
                table: "Traits",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 4, "It's your personal antidepressant", "Hobby" });

            migrationBuilder.InsertData(
                table: "Traits",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 5, "You are not snowflake", "Self-improvement" });

            migrationBuilder.InsertData(
                table: "Traits",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 6, "I bet you don't want to be cleaner at your middle age", "Carreer" });

            migrationBuilder.InsertData(
                table: "Traits",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 7, "Whatever you would say, it's material world", "Money" });

            migrationBuilder.InsertData(
                table: "Traits",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 8, "You won't work hard if you don't play hard", "Rest" });

            migrationBuilder.CreateIndex(
                name: "IX_Marks_TraitId",
                table: "Marks",
                column: "TraitId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_UserId",
                table: "Marks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DeleteData(
                table: "Traits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Traits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Traits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Traits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Traits",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Traits",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Traits",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Traits",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
