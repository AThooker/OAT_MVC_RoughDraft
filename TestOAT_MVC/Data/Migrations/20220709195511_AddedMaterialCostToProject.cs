using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestOAT_MVC.Data.Migrations
{
    public partial class AddedMaterialCostToProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Transactions",
                newName: "ProfitPerHour");

            migrationBuilder.AddColumn<double>(
                name: "PriceSoldAt",
                table: "Transactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaterialsCost",
                table: "Projects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceSoldAt",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "MaterialsCost",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProfitPerHour",
                table: "Transactions",
                newName: "Price");
        }
    }
}
