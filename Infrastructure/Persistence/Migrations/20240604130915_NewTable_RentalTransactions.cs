using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewTable_RentalTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "CarRentalTransactions",
                columns: table => new
                {
                    CarRentalTransactionsID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PickUpLocationID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DropOffLocationID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickUpDate = table.Column<DateOnly>(type: "Date", nullable: false),
                    DropOffDate = table.Column<DateOnly>(type: "Date", nullable: false),
                    PickUpTime = table.Column<TimeOnly>(type: "Time", nullable: false),
                    DropOffTime = table.Column<TimeOnly>(type: "Time", nullable: false),
                    CustomerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentalTransactions", x => x.CarRentalTransactionsID);
                    table.ForeignKey(
                        name: "FK_CarRentalTransactions_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRentalTransactions_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRentalTransactions_CarID",
                table: "CarRentalTransactions",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentalTransactions_CustomerID",
                table: "CarRentalTransactions",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRentalTransactions");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
