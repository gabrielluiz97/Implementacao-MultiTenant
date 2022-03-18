using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multitenant.Infraestructure.Migrations
{
    public partial class AddNewCoumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "test",
                table: "People",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test",
                table: "People");
        }
    }
}
