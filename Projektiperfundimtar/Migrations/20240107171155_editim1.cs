using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Find_me_a_roommate.Migrations
{
    public partial class editim1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Application");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Application",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Application");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Application",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
