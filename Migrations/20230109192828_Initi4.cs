using Microsoft.EntityFrameworkCore.Migrations;

namespace carsaApi.Migrations
{
    public partial class Initi4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcceptedOfferId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ColorCar",
                table: "Posts",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelCar",
                table: "Posts",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameCar",
                table: "Posts",
                type: "longtext",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptedOfferId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ColorCar",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ModelCar",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "NameCar",
                table: "Posts");
        }
    }
}
