using Microsoft.EntityFrameworkCore.Migrations;

namespace carsaApi.Migrations
{
    public partial class InitialCreate15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Posts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
