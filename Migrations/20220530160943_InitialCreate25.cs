using Microsoft.EntityFrameworkCore.Migrations;

namespace carsaApi.Migrations
{
    public partial class InitialCreate25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Products");
        }
    }
}
