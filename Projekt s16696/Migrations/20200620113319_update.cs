using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_s16696.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "clientToken",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "clientToken",
                table: "Clients");
        }
    }
}
