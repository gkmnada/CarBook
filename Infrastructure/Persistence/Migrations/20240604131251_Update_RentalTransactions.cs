using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update_RentalTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRentalTransactions");

            migrationBuilder.CreateTable(
                name: "RentalTransactions",
                columns: table => new
                {
                    RentalTransactionsID = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_RentalTransactions", x => x.RentalTransactionsID);
                    table.ForeignKey(
                        name: "FK_RentalTransactions_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalTransactions_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalTransactions_CarID",
                table: "RentalTransactions",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalTransactions_CustomerID",
                table: "RentalTransactions",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalTransactions");

            migrationBuilder.CreateTable(
                name: "CarRentalTransactions",
                columns: table => new
                {
                    CarRentalTransactionsID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DropOffDate = table.Column<DateOnly>(type: "Date", nullable: false),
                    DropOffLocationID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DropOffTime = table.Column<TimeOnly>(type: "Time", nullable: false),
                    PickUpDate = table.Column<DateOnly>(type: "Date", nullable: false),
                    PickUpLocationID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickUpTime = table.Column<TimeOnly>(type: "Time", nullable: false),
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
    }
}
