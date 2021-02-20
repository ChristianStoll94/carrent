using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.Migrations
{
    public partial class createdContractTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReservationId = table.Column<int>(nullable: false),
                    PickupDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CarId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_car_CarId",
                        column: x => x.CarId,
                        principalTable: "car",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contract_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Contract_CarId",
                table: "Contract",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_CustomerId",
                table: "Contract",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.UpdateData(
                table: "carclass",
                keyColumn: "description",
                keyValue: "Einfachklasse",
                column: "price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "carclass",
                keyColumn: "description",
                keyValue: "Luxusklasse",
                column: "price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "carclass",
                keyColumn: "description",
                keyValue: "Mittelklasse",
                column: "price",
                value: 0m);
        }
    }
}
