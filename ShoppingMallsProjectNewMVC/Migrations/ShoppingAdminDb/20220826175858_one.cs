using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingMallsProjectNewMVC.Migrations.ShoppingAdminDb
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ShoppingMallModels",
                type: "VARCHAR(10)",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ShoppingMallModels");
        }
    }
}
