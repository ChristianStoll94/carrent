using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.Migrations
{
    public partial class renameId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Customer",
                table: "customer",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "customer",
                newName: "Customer");
        }
    }
}
