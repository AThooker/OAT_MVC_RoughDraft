using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestOAT_MVC.Data.Migrations
{
    public partial class testingEnumDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Projects",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projects",
                newName: "ID");
        }
    }
}
