using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingMallsProjectNewMVC.Migrations.ShoppingAdminDb
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingMallModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PanNumber = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    ConfirmPassword = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    RoleName = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingMallModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingMallModels_Email",
                table: "ShoppingMallModels",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingMallModels");
        }
    }
}
