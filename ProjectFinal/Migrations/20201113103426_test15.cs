using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectFinal.Migrations
{
    public partial class test15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfCustomer",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerNumber",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerNumber",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfCustomer",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
