using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingMallsProjectNewMVC.Migrations.ShoppingAdminDb
{
    public partial class duo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ShoppingMallModels",
                type: "VARCHAR(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsApproved",
                table: "ShoppingMallModels",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "ShoppingMallModels");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ShoppingMallModels",
                type: "VARCHAR(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)",
                oldMaxLength: 10);
        }
    }
}
