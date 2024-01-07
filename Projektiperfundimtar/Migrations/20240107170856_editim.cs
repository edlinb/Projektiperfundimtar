using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Find_me_a_roommate.Migrations
{
    public partial class editim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Application");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Application",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
