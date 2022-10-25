using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfLog.Migrations
{
    public partial class Initail9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartFuncsFunction");

            migrationBuilder.DropTable(
                name: "CartFuncs");

            migrationBuilder.AddColumn<int>(
                name: "Orderid",
                table: "Functions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Usingid",
                table: "Functions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    funcid = table.Column<int>(type: "int", nullable: false),
                    Checked = table.Column<bool>(type: "bit", nullable: false),
                    CartId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_CartItems_Functions_funcid",
                        column: x => x.funcid,
                        principalTable: "Functions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Using",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orderid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Using", x => x.id);
                    table.ForeignKey(
                        name: "FK_Using_Orders_Orderid",
                        column: x => x.Orderid,
                        principalTable: "Orders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Functions_Orderid",
                table: "Functions",
                column: "Orderid");

            migrationBuilder.CreateIndex(
                name: "IX_Functions_Usingid",
                table: "Functions",
                column: "Usingid");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_funcid",
                table: "CartItems",
                column: "funcid");

            migrationBuilder.CreateIndex(
                name: "IX_Using_Orderid",
                table: "Using",
                column: "Orderid");

            migrationBuilder.AddForeignKey(
                name: "FK_Functions_Orders_Orderid",
                table: "Functions",
                column: "Orderid",
                principalTable: "Orders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Functions_Using_Usingid",
                table: "Functions",
                column: "Usingid",
                principalTable: "Using",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Functions_Orders_Orderid",
                table: "Functions");

            migrationBuilder.DropForeignKey(
                name: "FK_Functions_Using_Usingid",
                table: "Functions");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Using");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Functions_Orderid",
                table: "Functions");

            migrationBuilder.DropIndex(
                name: "IX_Functions_Usingid",
                table: "Functions");

            migrationBuilder.DropColumn(
                name: "Orderid",
                table: "Functions");

            migrationBuilder.DropColumn(
                name: "Usingid",
                table: "Functions");

            migrationBuilder.CreateTable(
                name: "CartFuncs",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartFuncs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CartFuncsFunction",
                columns: table => new
                {
                    CartFuncsid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Functionsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartFuncsFunction", x => new { x.CartFuncsid, x.Functionsid });
                    table.ForeignKey(
                        name: "FK_CartFuncsFunction_CartFuncs_CartFuncsid",
                        column: x => x.CartFuncsid,
                        principalTable: "CartFuncs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartFuncsFunction_Functions_Functionsid",
                        column: x => x.Functionsid,
                        principalTable: "Functions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartFuncsFunction_Functionsid",
                table: "CartFuncsFunction",
                column: "Functionsid");
        }
    }
}
