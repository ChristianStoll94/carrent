using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.Migrations
{
    public partial class AddedReservationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "carclass",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(45)");

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    startdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    enddate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.id);
                    table.ForeignKey(
                        name: "FK_reservation_car_CarId",
                        column: x => x.CarId,
                        principalTable: "car",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservation_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "carclass",
                keyColumn: "description",
                keyValue: "Einfachklasse",
                column: "price",
                value: 13.5m);

            migrationBuilder.UpdateData(
                table: "carclass",
                keyColumn: "description",
                keyValue: "Luxusklasse",
                column: "price",
                value: 35.45m);

            migrationBuilder.UpdateData(
                table: "carclass",
                keyColumn: "description",
                keyValue: "Mittelklasse",
                column: "price",
                value: 20.6m);

            migrationBuilder.CreateIndex(
                name: "IX_reservation_CarId",
                table: "reservation",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_CustomerId",
                table: "reservation",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.AlterColumn<string>(
                name: "price",
                table: "carclass",
                type: "varchar(45)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.UpdateData(
                table: "carclass",
                keyColumn: "description",
                keyValue: "Einfachklasse",
                column: "price",
                value: null);

            migrationBuilder.UpdateData(
                table: "carclass",
                keyColumn: "description",
                keyValue: "Luxusklasse",
                column: "price",
                value: null);

            migrationBuilder.UpdateData(
                table: "carclass",
                keyColumn: "description",
                keyValue: "Mittelklasse",
                column: "price",
                value: null);
        }
    }
}
