using Microsoft.EntityFrameworkCore.Migrations;

namespace carsaApi.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameProduct",
                table: "Carts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameProduct",
                table: "Carts");
        }
    }
}
