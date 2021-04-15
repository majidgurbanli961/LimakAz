using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectFinal.Migrations
{
    public partial class F_CreateCourierTableFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourierDeliveries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveredStatus = table.Column<int>(nullable: false),
                    AddressOfDelivery = table.Column<int>(nullable: false),
                    District = table.Column<string>(maxLength: 70, nullable: true),
                    Village = table.Column<string>(maxLength: 70, nullable: true),
                    Street = table.Column<string>(maxLength: 70, nullable: true),
                    House = table.Column<string>(maxLength: 70, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: true),
                    InvoiceComments = table.Column<string>(maxLength: 500, nullable: true),
                    DbPassportUserModelId = table.Column<string>(nullable: true),
                    InvoiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierDeliveries", x => x.id);
                    table.ForeignKey(
                        name: "FK_CourierDeliveries_AspNetUsers_DbPassportUserModelId",
                        column: x => x.DbPassportUserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourierDeliveries_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourierDeliveries_DbPassportUserModelId",
                table: "CourierDeliveries",
                column: "DbPassportUserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierDeliveries_InvoiceId",
                table: "CourierDeliveries",
                column: "InvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourierDeliveries");
        }
    }
}
