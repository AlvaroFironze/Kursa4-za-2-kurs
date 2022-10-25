using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfLog.Migrations
{
    public partial class Initail8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartFuncsFunction");

            migrationBuilder.DropTable(
                name: "CartFuncs");

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
                name: "IX_CartItems_funcid",
                table: "CartItems",
                column: "funcid");
        }
    }
}
