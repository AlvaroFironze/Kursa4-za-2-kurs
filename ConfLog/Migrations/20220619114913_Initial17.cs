using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfLog.Migrations
{
    public partial class Initial17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "toUse",
                table: "Functions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "toUse",
                table: "Functions");
        }
    }
}
