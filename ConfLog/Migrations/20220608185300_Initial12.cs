using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfLog.Migrations
{
    public partial class Initial12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Functions_Using_Usingid",
                table: "Functions");

            migrationBuilder.DropForeignKey(
                name: "FK_Using_Orders_Orderid",
                table: "Using");

            migrationBuilder.DropIndex(
                name: "IX_Functions_Usingid",
                table: "Functions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Using",
                table: "Using");

            migrationBuilder.DropIndex(
                name: "IX_Using_Orderid",
                table: "Using");

            migrationBuilder.DropColumn(
                name: "Usingid",
                table: "Functions");

            migrationBuilder.DropColumn(
                name: "Orderid",
                table: "Using");

            migrationBuilder.RenameTable(
                name: "Using",
                newName: "Usings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usings",
                table: "Usings",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FunctionUsing",
                columns: table => new
                {
                    functionsid = table.Column<int>(type: "int", nullable: false),
                    usingsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionUsing", x => new { x.functionsid, x.usingsid });
                    table.ForeignKey(
                        name: "FK_FunctionUsing_Functions_functionsid",
                        column: x => x.functionsid,
                        principalTable: "Functions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FunctionUsing_Usings_usingsid",
                        column: x => x.usingsid,
                        principalTable: "Usings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldFunction",
                columns: table => new
                {
                    fieldsid = table.Column<int>(type: "int", nullable: false),
                    functionsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldFunction", x => new { x.fieldsid, x.functionsid });
                    table.ForeignKey(
                        name: "FK_FieldFunction_Fields_fieldsid",
                        column: x => x.fieldsid,
                        principalTable: "Fields",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldFunction_Functions_functionsid",
                        column: x => x.functionsid,
                        principalTable: "Functions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldFunction_functionsid",
                table: "FieldFunction",
                column: "functionsid");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionUsing_usingsid",
                table: "FunctionUsing",
                column: "usingsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldFunction");

            migrationBuilder.DropTable(
                name: "FunctionUsing");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usings",
                table: "Usings");

            migrationBuilder.RenameTable(
                name: "Usings",
                newName: "Using");

            migrationBuilder.AddColumn<int>(
                name: "Usingid",
                table: "Functions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Orderid",
                table: "Using",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Using",
                table: "Using",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Functions_Usingid",
                table: "Functions",
                column: "Usingid");

            migrationBuilder.CreateIndex(
                name: "IX_Using_Orderid",
                table: "Using",
                column: "Orderid");

            migrationBuilder.AddForeignKey(
                name: "FK_Functions_Using_Usingid",
                table: "Functions",
                column: "Usingid",
                principalTable: "Using",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Using_Orders_Orderid",
                table: "Using",
                column: "Orderid",
                principalTable: "Orders",
                principalColumn: "id");
        }
    }
}
