using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerAPI.Migrations
{
    public partial class IntialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "Country", "CreatedAt", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber", "State", "UpdatedAt", "ZipCode" },
                values: new object[] { new Guid("00e5bde8-5f62-44f4-a2bc-691935ae26c7"), "", "", "", new DateTime(2025, 8, 1, 15, 57, 37, 21, DateTimeKind.Utc).AddTicks(1730), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Test ", "Test 1", "", "", new DateTime(2025, 8, 1, 15, 57, 37, 21, DateTimeKind.Utc).AddTicks(1731), "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
