using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectFinal.Migrations
{
    public partial class F_MakeOrderInsideDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TLBalance = table.Column<decimal>(nullable: false),
                    AZNBalance = table.Column<decimal>(nullable: false),
                    LastIncreasedAZNBalanceDate = table.Column<DateTime>(nullable: false),
                    DbPassportUserModelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.id);
                    table.ForeignKey(
                        name: "FK_Balances_AspNetUsers_DbPassportUserModelId",
                        column: x => x.DbPassportUserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(nullable: false),
                    InvoiceProductType = table.Column<string>(nullable: false),
                    InvoiceProductAmount = table.Column<int>(nullable: false),
                    InvoiceProductPrice = table.Column<decimal>(nullable: false),
                    InvoiceFollowCode = table.Column<string>(nullable: false),
                    DeliveryOffice = table.Column<int>(nullable: false),
                    InvoiceDate = table.Column<DateTime>(nullable: true),
                    InvoiceComments = table.Column<string>(maxLength: 500, nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    InvoiceNumber = table.Column<int>(nullable: true),
                    InvoiceProductWeight = table.Column<decimal>(nullable: true),
                    DeliveryMoney = table.Column<decimal>(nullable: true),
                    InvoiceTime = table.Column<string>(nullable: true),
                    InvoiceStatus = table.Column<int>(nullable: false),
                    InvoiceCountryIndex = table.Column<int>(nullable: false),
                    DbPassportUserModelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_Invoices_AspNetUsers_DbPassportUserModelId",
                        column: x => x.DbPassportUserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balances_DbPassportUserModelId",
                table: "Balances",
                column: "DbPassportUserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_DbPassportUserModelId",
                table: "Invoices",
                column: "DbPassportUserModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
