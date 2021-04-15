using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectFinal.Migrations
{
    public partial class F_CreateBalancesTableWithoutId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_AspNetUsers_DbPassportUserModelId1",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_DbPassportUserModelId1",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "DbPassportUserModelId1",
                table: "Balances");

            migrationBuilder.AlterColumn<string>(
                name: "DbPassportUserModelId",
                table: "Balances",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_DbPassportUserModelId",
                table: "Balances",
                column: "DbPassportUserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_AspNetUsers_DbPassportUserModelId",
                table: "Balances",
                column: "DbPassportUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_AspNetUsers_DbPassportUserModelId",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_DbPassportUserModelId",
                table: "Balances");

            migrationBuilder.AlterColumn<int>(
                name: "DbPassportUserModelId",
                table: "Balances",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DbPassportUserModelId1",
                table: "Balances",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Balances_DbPassportUserModelId1",
                table: "Balances",
                column: "DbPassportUserModelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_AspNetUsers_DbPassportUserModelId1",
                table: "Balances",
                column: "DbPassportUserModelId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
