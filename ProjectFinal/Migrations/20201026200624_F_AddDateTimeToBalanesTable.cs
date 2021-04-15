using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectFinal.Migrations
{
    public partial class F_AddDateTimeToBalanesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastIncreasedBalanceDate",
                table: "Balances",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastIncreasedBalanceDate",
                table: "Balances");
        }
    }
}
