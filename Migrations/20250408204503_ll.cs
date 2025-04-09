using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app1.Migrations
{
    /// <inheritdoc />
    public partial class ll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categreid",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categres_Categres_CategreId",
                        column: x => x.CategreId,
                        principalTable: "Categres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_categreid",
                table: "Products",
                column: "categreid");

            migrationBuilder.CreateIndex(
                name: "IX_Categres_CategreId",
                table: "Categres",
                column: "CategreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categres_categreid",
                table: "Products",
                column: "categreid",
                principalTable: "Categres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categres_categreid",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categres");

            migrationBuilder.DropIndex(
                name: "IX_Products_categreid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "categreid",
                table: "Products");
        }
    }
}
