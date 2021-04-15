using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectFinal.Migrations
{
    public partial class F_RelateUserInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_UserInvoices_UserInvoicesid",
                table: "Invoice");

            migrationBuilder.DropTable(
                name: "UserInvoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_UserInvoicesid",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "UserInvoicesid",
                table: "Invoice");

            migrationBuilder.AddColumn<string>(
                name: "DbPassportUserModelId",
                table: "Invoice",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_DbPassportUserModelId",
                table: "Invoice",
                column: "DbPassportUserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_AspNetUsers_DbPassportUserModelId",
                table: "Invoice",
                column: "DbPassportUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_AspNetUsers_DbPassportUserModelId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_DbPassportUserModelId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "DbPassportUserModelId",
                table: "Invoice");

            migrationBuilder.AddColumn<int>(
                name: "UserInvoicesid",
                table: "Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserInvoices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_UserInvoicesid",
                table: "Invoice",
                column: "UserInvoicesid");

            migrationBuilder.CreateIndex(
                name: "IX_UserInvoices_UserId",
                table: "UserInvoices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_UserInvoices_UserInvoicesid",
                table: "Invoice",
                column: "UserInvoicesid",
                principalTable: "UserInvoices",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
