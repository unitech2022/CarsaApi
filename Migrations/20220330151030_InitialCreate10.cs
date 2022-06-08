using Microsoft.EntityFrameworkCore.Migrations;

namespace carsaApi.Migrations
{
    public partial class InitialCreate10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCart",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "IsFav",
                table: "Favorites");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Favorites",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Favorites");

            migrationBuilder.AddColumn<bool>(
                name: "IsCart",
                table: "Favorites",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFav",
                table: "Favorites",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
