using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StorageManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddGateEntryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GateEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryReference = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CheckIn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CheckOut = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EntryType = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateEntries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GateEntries");
        }
    }
}
