using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectFinal.Migrations
{
    public partial class F_SomChangesas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_AspNetUsers_DbPassportUserModelId",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_DbPassportUserModelId",
                table: "Invoices",
                newName: "IX_Invoices_DbPassportUserModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_DbPassportUserModelId",
                table: "Invoices",
                column: "DbPassportUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_DbPassportUserModelId",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_DbPassportUserModelId",
                table: "Invoice",
                newName: "IX_Invoice_DbPassportUserModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_AspNetUsers_DbPassportUserModelId",
                table: "Invoice",
                column: "DbPassportUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
