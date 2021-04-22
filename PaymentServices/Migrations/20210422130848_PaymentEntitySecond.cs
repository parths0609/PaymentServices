using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentServices.Migrations
{
    public partial class PaymentEntitySecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentStatus_PaymentRequest_CreditCardNoCreditCardNumber",
                table: "PaymentStatus");

            migrationBuilder.DropIndex(
                name: "IX_PaymentStatus_CreditCardNoCreditCardNumber",
                table: "PaymentStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentRequest",
                table: "PaymentRequest");

            migrationBuilder.DropColumn(
                name: "CreditCardNoCreditCardNumber",
                table: "PaymentStatus");

            migrationBuilder.AddColumn<int>(
                name: "RequestLogId1",
                table: "PaymentStatus",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreditCardNumber",
                table: "PaymentRequest",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "RequestLogId",
                table: "PaymentRequest",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentRequest",
                table: "PaymentRequest",
                column: "RequestLogId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStatus_RequestLogId1",
                table: "PaymentStatus",
                column: "RequestLogId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentStatus_PaymentRequest_RequestLogId1",
                table: "PaymentStatus",
                column: "RequestLogId1",
                principalTable: "PaymentRequest",
                principalColumn: "RequestLogId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentStatus_PaymentRequest_RequestLogId1",
                table: "PaymentStatus");

            migrationBuilder.DropIndex(
                name: "IX_PaymentStatus_RequestLogId1",
                table: "PaymentStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentRequest",
                table: "PaymentRequest");

            migrationBuilder.DropColumn(
                name: "RequestLogId1",
                table: "PaymentStatus");

            migrationBuilder.DropColumn(
                name: "RequestLogId",
                table: "PaymentRequest");

            migrationBuilder.AddColumn<string>(
                name: "CreditCardNoCreditCardNumber",
                table: "PaymentStatus",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreditCardNumber",
                table: "PaymentRequest",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentRequest",
                table: "PaymentRequest",
                column: "CreditCardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStatus_CreditCardNoCreditCardNumber",
                table: "PaymentStatus",
                column: "CreditCardNoCreditCardNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentStatus_PaymentRequest_CreditCardNoCreditCardNumber",
                table: "PaymentStatus",
                column: "CreditCardNoCreditCardNumber",
                principalTable: "PaymentRequest",
                principalColumn: "CreditCardNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
