using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Multitenant.API.Migrations
{
    public partial class Estrategia02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "People",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "People",
                columns: new[] { "Id", "Name", "TenantId" },
                values: new object[,]
                {
                    { 1, "Person 1", "tenant-1" },
                    { 2, "Person 2", "tenant-2" },
                    { 3, "Person 3", "tenant-3" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Products",
                columns: new[] { "Id", "Description", "TenantId" },
                values: new object[,]
                {
                    { 1, "Description 1", "tenant-1" },
                    { 2, "Description 2", "tenant-2" },
                    { 3, "Description 3", "tenant-3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "public");
        }
    }
}
