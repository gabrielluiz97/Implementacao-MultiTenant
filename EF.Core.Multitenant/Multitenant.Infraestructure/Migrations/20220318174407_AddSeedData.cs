using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multitenant.Infraestructure.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Name", "test" },
                values: new object[,]
                {
                    { 1, "Person 1", null },
                    { 2, "Person 2", null },
                    { 3, "Person 3", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Description 1" },
                    { 2, "Description 2" },
                    { 3, "Description 3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
