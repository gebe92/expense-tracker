using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionDetails",
                columns: table => new
                {
                    transID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    transAmt = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    transUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetails", x => x.transID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionDetails");
        }
    }
}
