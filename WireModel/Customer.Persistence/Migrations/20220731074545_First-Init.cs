using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.Persistence.Migrations
{
    public partial class FirstInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CustomerContext");

            migrationBuilder.EnsureSchema(
                name: "Shared");

            migrationBuilder.CreateSequence(
                name: "Customer",
                schema: "Shared");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "CustomerContext",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BigInt", nullable: false, defaultValueSql: "NEXT VALUE FOR shared.Customer"),
                    FirstName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer",
                schema: "CustomerContext");

            migrationBuilder.DropSequence(
                name: "Customer",
                schema: "Shared");
        }
    }
}
