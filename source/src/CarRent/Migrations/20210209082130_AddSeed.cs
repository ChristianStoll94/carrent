using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.Migrations
{
    public partial class AddSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "carclass",
                columns: new[] { "description", "price" },
                values: new object[] { "Einfachklasse", "13.5" });

            migrationBuilder.InsertData(
                table: "carclass",
                columns: new[] { "description", "price" },
                values: new object[] { "Mittelklasse", "20.6" });

            migrationBuilder.InsertData(
                table: "carclass",
                columns: new[] { "description", "price" },
                values: new object[] { "Luxusklasse", "35.45" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "carclass",
                keyColumn: "description",
                keyValue: "Einfachklasse");

            migrationBuilder.DeleteData(
                table: "carclass",
                keyColumn: "description",
                keyValue: "Luxusklasse");

            migrationBuilder.DeleteData(
                table: "carclass",
                keyColumn: "description",
                keyValue: "Mittelklasse");
        }
    }
}
