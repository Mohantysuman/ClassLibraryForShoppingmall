using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryForShoppingmall.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Malls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingMallName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    ShoppingMallCity = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    ShoppingMallState = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malls", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Malls_ShoppingMallName",
                table: "Malls",
                column: "ShoppingMallName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Malls");
        }
    }
}
