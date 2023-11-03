using Microsoft.EntityFrameworkCore.Migrations;

namespace carsaApi.Migrations
{
    public partial class Initi1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Workshops",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneWhats",
                table: "Workshops",
                type: "longtext",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Workshops");

            migrationBuilder.DropColumn(
                name: "PhoneWhats",
                table: "Workshops");
        }
    }
}
