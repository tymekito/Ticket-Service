using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketsAPI.Migrations
{
    public partial class addwalletpropertytouseraccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Wallet",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wallet",
                table: "Users");
        }
    }
}
