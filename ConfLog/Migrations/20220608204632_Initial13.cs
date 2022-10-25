using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfLog.Migrations
{
    public partial class Initial13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Functions_Orders_Orderid",
                table: "Functions");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_Functions_Orderid",
                table: "Functions");

            migrationBuilder.DropColumn(
                name: "Orderid",
                table: "Functions");

            migrationBuilder.AddColumn<string>(
                name: "result",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Constructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    field = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FunctionOrder",
                columns: table => new
                {
                    functionsid = table.Column<int>(type: "int", nullable: false),
                    ordersid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionOrder", x => new { x.functionsid, x.ordersid });
                    table.ForeignKey(
                        name: "FK_FunctionOrder_Functions_functionsid",
                        column: x => x.functionsid,
                        principalTable: "Functions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FunctionOrder_Orders_ordersid",
                        column: x => x.ordersid,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConstructorOrder",
                columns: table => new
                {
                    constructorsId = table.Column<int>(type: "int", nullable: false),
                    ordersid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructorOrder", x => new { x.constructorsId, x.ordersid });
                    table.ForeignKey(
                        name: "FK_ConstructorOrder_Constructors_constructorsId",
                        column: x => x.constructorsId,
                        principalTable: "Constructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstructorOrder_Orders_ordersid",
                        column: x => x.ordersid,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstructorOrder_ordersid",
                table: "ConstructorOrder",
                column: "ordersid");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionOrder_ordersid",
                table: "FunctionOrder",
                column: "ordersid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstructorOrder");

            migrationBuilder.DropTable(
                name: "FunctionOrder");

            migrationBuilder.DropTable(
                name: "Constructors");

            migrationBuilder.DropColumn(
                name: "result",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Orderid",
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
                    CartId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Checked = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Functions_Orderid",
                table: "Functions",
                column: "Orderid");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_funcid",
                table: "CartItems",
                column: "funcid");

            migrationBuilder.AddForeignKey(
                name: "FK_Functions_Orders_Orderid",
                table: "Functions",
                column: "Orderid",
                principalTable: "Orders",
                principalColumn: "id");
        }
    }
}
