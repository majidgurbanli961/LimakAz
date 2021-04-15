using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectFinal.Migrations
{
    public partial class test13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
               name: "NumberOfCustomer",
               table: "AspNetUsers",
               nullable: false)
               .Annotation("SqlServer:Identity", "10000000, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfCustomer",
                table: "AspNetUsers");
        }
    }
}
