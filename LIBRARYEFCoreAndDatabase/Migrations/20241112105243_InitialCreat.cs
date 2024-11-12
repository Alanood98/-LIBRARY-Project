using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIBRARYEFCoreAndDatabase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admines",
                columns: table => new
                {
                    AID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apassword = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    AEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admines", x => x.AID);
                });

            migrationBuilder.CreateTable(
                name: "Categoryes",
                columns: table => new
                {
                    CID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfBooks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoryes", x => x.CID);
                });

            migrationBuilder.CreateTable(
                name: "Useres",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Upassword = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    Uname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ugender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Useres", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "Bookes",
                columns: table => new
                {
                    BID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bauthor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorrowedCopies = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    BorrTotalCopy = table.Column<int>(type: "int", nullable: false),
                    CID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookes", x => x.BID);
                    table.ForeignKey(
                        name: "FK_Bookes_Categoryes_CID",
                        column: x => x.CID,
                        principalTable: "Categoryes",
                        principalColumn: "CID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowingBookes",
                columns: table => new
                {
                    BID = table.Column<int>(type: "int", nullable: false),
                    UID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    BRdate = table.Column<DateOnly>(type: "date", nullable: false),
                    predictDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ActualDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsReturen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowingBookes", x => new { x.BID, x.UID });
                    table.ForeignKey(
                        name: "FK_BorrowingBookes_Bookes_BID",
                        column: x => x.BID,
                        principalTable: "Bookes",
                        principalColumn: "BID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowingBookes_Useres_UID",
                        column: x => x.UID,
                        principalTable: "Useres",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookes_CID",
                table: "Bookes",
                column: "CID");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingBookes_UID",
                table: "BorrowingBookes",
                column: "UID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admines");

            migrationBuilder.DropTable(
                name: "BorrowingBookes");

            migrationBuilder.DropTable(
                name: "Bookes");

            migrationBuilder.DropTable(
                name: "Useres");

            migrationBuilder.DropTable(
                name: "Categoryes");
        }
    }
}
