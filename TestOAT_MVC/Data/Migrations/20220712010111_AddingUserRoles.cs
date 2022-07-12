using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestOAT_MVC.Data.Migrations
{
    public partial class AddingUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectIndexDto");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c5e174e-3A0e-446f-56af-324d56fd7210", "eb1de56f-8924-436f-9afc-2b832b025b34", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "86AB4865-a24d-3543-a6c6-8443d048cdb9", 0, "e41c3c09-f60e-4c61-ab2f-ec92abbe7ec7", null, false, false, null, null, "AUSTIN", "AQAAAAEAACcQAAAAELDndZSUv54LkC6oE1qtSAElyR2xRlyCTzlfMh8oEJR2iL7b1Cw0KM4U1GX8lnr2RA==", null, false, "f1640116-f457-4c4b-854d-f3886ce3c7d6", false, "AustinT" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "96AB4865-a24d-4543-a6c6-9443d048cdb9", 0, "9b7ae703-52b6-4879-bb75-c6bdaa1ed1e7", null, false, false, null, null, "OLIVIA", "AQAAAAEAACcQAAAAEG/K2RiQSgHu+vzxIodBLhu7mCXcgsAtQPWC5+lerVwb9bDRmKdKu2GeuYb/dqqb6g==", null, false, "38d5a2b7-255d-49e4-bd9c-b916c05a859e", false, "OliviaK" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3c5e174e-3A0e-446f-56af-324d56fd7210", "86AB4865-a24d-3543-a6c6-8443d048cdb9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3c5e174e-3A0e-446f-56af-324d56fd7210", "96AB4865-a24d-4543-a6c6-9443d048cdb9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3c5e174e-3A0e-446f-56af-324d56fd7210", "86AB4865-a24d-3543-a6c6-8443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3c5e174e-3A0e-446f-56af-324d56fd7210", "96AB4865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c5e174e-3A0e-446f-56af-324d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86AB4865-a24d-3543-a6c6-8443d048cdb9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "96AB4865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.CreateTable(
                name: "ProjectIndexDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    DatePurchased = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoursDedicated = table.Column<double>(type: "float", nullable: false),
                    PurchasePrice = table.Column<double>(type: "float", nullable: false),
                    Sold = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectIndexDto", x => x.Id);
                });
        }
    }
}
