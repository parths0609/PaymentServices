using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentServices.Migrations
{
    public partial class PaymentEntityFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentRequest",
                columns: table => new
                {
                    CreditCardNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CardHolder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecurityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRequest", x => x.CreditCardNumber);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardNoCreditCardNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PaymentState = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatus", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_PaymentStatus_PaymentRequest_CreditCardNoCreditCardNumber",
                        column: x => x.CreditCardNoCreditCardNumber,
                        principalTable: "PaymentRequest",
                        principalColumn: "CreditCardNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStatus_CreditCardNoCreditCardNumber",
                table: "PaymentStatus",
                column: "CreditCardNoCreditCardNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "PaymentRequest");
        }
    }
}
