using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multitenant.Infraestructure.Migrations
{
    public partial class RemoveColumnTestIntoTablePerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test",
                table: "People");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "test",
                table: "People",
                type: "integer",
                nullable: true);
        }
    }
}
