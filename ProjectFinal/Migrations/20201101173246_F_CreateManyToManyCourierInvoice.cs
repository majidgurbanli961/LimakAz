using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectFinal.Migrations
{
    public partial class F_CreateManyToManyCourierInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourierDeliveries_Invoices_InvoiceId",
                table: "CourierDeliveries");

            migrationBuilder.DropIndex(
                name: "IX_CourierDeliveries_InvoiceId",
                table: "CourierDeliveries");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "CourierDeliveries");

            migrationBuilder.CreateTable(
                name: "CourierDbViewModelInvoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false),
                    CourierDbViewModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierDbViewModelInvoices", x => new { x.InvoiceId, x.CourierDbViewModelId });
                    table.ForeignKey(
                        name: "FK_CourierDbViewModelInvoices_CourierDeliveries_CourierDbViewModelId",
                        column: x => x.CourierDbViewModelId,
                        principalTable: "CourierDeliveries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourierDbViewModelInvoices_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourierDbViewModelInvoices_CourierDbViewModelId",
                table: "CourierDbViewModelInvoices",
                column: "CourierDbViewModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourierDbViewModelInvoices");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "CourierDeliveries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CourierDeliveries_InvoiceId",
                table: "CourierDeliveries",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourierDeliveries_Invoices_InvoiceId",
                table: "CourierDeliveries",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
