using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectFinal.Migrations
{
    public partial class F_AddInvoiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInvoices",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInvoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserInvoices_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(nullable: false),
                    InvoiceProductType = table.Column<string>(nullable: false),
                    InvoiceProductAmount = table.Column<int>(nullable: false),
                    InvoiceProductPrice = table.Column<int>(nullable: false),
                    InvoiceFollowCode = table.Column<string>(nullable: false),
                    DeliveryOffice = table.Column<int>(nullable: false),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    InvoiceComments = table.Column<string>(maxLength: 500, nullable: false),
                    FileName = table.Column<string>(nullable: false),
                    InvoiceNumber = table.Column<int>(nullable: false),
                    InvoiceProductWeight = table.Column<decimal>(nullable: true),
                    DeliveryMoney = table.Column<decimal>(nullable: true),
                    InvoiceTime = table.Column<DateTime>(nullable: false),
                    InvoiceStatus = table.Column<int>(nullable: false),
                    InvoiceCountryIndex = table.Column<int>(nullable: false),
                    UserInvoicesid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.id);
                    table.ForeignKey(
                        name: "FK_Invoice_UserInvoices_UserInvoicesid",
                        column: x => x.UserInvoicesid,
                        principalTable: "UserInvoices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_UserInvoicesid",
                table: "Invoice",
                column: "UserInvoicesid");

            migrationBuilder.CreateIndex(
                name: "IX_UserInvoices_UserId",
                table: "UserInvoices",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "UserInvoices");
        }
    }
}
