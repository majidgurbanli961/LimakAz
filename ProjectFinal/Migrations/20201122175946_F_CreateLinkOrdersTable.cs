using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectFinal.Migrations
{
    public partial class F_CreateLinkOrdersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderLink = table.Column<string>(maxLength: 255, nullable: false),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    ProductAmount = table.Column<int>(nullable: false),
                    OrderComment = table.Column<string>(maxLength: 500, nullable: true),
                    PaymentMethod = table.Column<int>(nullable: false),
                    DeliveryAddress = table.Column<int>(nullable: false),
                    DbPassportUserModelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_DbPassportUserModelId",
                        column: x => x.DbPassportUserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DbPassportUserModelId",
                table: "Orders",
                column: "DbPassportUserModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
