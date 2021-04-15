using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectFinal.Migrations
{
    public partial class F_AddWeightDeliveryMoneyToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryMoney",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InvoiceProductWeight",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryMoney",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InvoiceProductWeight",
                table: "Orders");
        }
    }
}
