using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectFinal.Migrations
{
    public partial class F_CreateBalancesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TLBalance = table.Column<decimal>(nullable: false),
                    AZNBalance = table.Column<decimal>(nullable: false),
                    DbPassportUserModelId = table.Column<int>(nullable: false),
                    DbPassportUserModelId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.id);
                    table.ForeignKey(
                        name: "FK_Balances_AspNetUsers_DbPassportUserModelId1",
                        column: x => x.DbPassportUserModelId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balances_DbPassportUserModelId1",
                table: "Balances",
                column: "DbPassportUserModelId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balances");
        }
    }
}
