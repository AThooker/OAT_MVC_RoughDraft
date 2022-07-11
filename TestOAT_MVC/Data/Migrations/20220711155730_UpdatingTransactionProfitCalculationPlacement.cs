using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestOAT_MVC.Data.Migrations
{
    public partial class UpdatingTransactionProfitCalculationPlacement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Projects_ProjectID",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "Transactions",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_ProjectID",
                table: "Transactions",
                newName: "IX_Transactions_ProjectId");

            migrationBuilder.AlterColumn<double>(
                name: "ProfitPerHour",
                table: "Transactions",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<double>(
                name: "Profit",
                table: "Transactions",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectIndexDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasePrice = table.Column<double>(type: "float", nullable: false),
                    DatePurchased = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoursDedicated = table.Column<double>(type: "float", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    Sold = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectIndexDto", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Projects_ProjectId",
                table: "Transactions",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Projects_ProjectId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "ProjectIndexDto");

            migrationBuilder.DropColumn(
                name: "Profit",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Transactions",
                newName: "ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_ProjectId",
                table: "Transactions",
                newName: "IX_Transactions_ProjectID");

            migrationBuilder.AlterColumn<double>(
                name: "ProfitPerHour",
                table: "Transactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Projects_ProjectID",
                table: "Transactions",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
