using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackRockEvents.Migrations
{
    public partial class takeoutdescriptionpropertyunneeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Professionals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Professionals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
