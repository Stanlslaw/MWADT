using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab8.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneRecords", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PhoneRecords",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[] { new Guid("602fa94c-1cb3-45bb-bd57-054d32f01b66"), "Stas", "+375295200444" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneRecords");
        }
    }
}
