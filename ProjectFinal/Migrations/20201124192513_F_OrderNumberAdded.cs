using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectFinal.Migrations
{
    public partial class F_OrderNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceProductWeight",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OrderProductWeight",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderProductWeight",
                table: "Orders");

            migrationBuilder.AddColumn<decimal>(
                name: "InvoiceProductWeight",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
