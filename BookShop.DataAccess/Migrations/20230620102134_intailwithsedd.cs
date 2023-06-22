using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.DataAccess.Migrations
{
    public partial class intailwithsedd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDateTime", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 20, 20, 21, 33, 861, DateTimeKind.Local).AddTicks(8459), 1, "helu" },
                    { 2, new DateTime(2023, 6, 20, 20, 21, 33, 861, DateTimeKind.Local).AddTicks(8485), 1, "helu" },
                    { 3, new DateTime(2023, 6, 20, 20, 21, 33, 861, DateTimeKind.Local).AddTicks(8487), 1, "helu" },
                    { 4, new DateTime(2023, 6, 20, 20, 21, 33, 861, DateTimeKind.Local).AddTicks(8489), 1, "helu" },
                    { 5, new DateTime(2023, 6, 20, 20, 21, 33, 861, DateTimeKind.Local).AddTicks(8490), 1, "helu" },
                    { 6, new DateTime(2023, 6, 20, 20, 21, 33, 861, DateTimeKind.Local).AddTicks(8492), 1, "helu" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
