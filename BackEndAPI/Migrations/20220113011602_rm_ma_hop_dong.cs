using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class rm_ma_hop_dong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MA_HOP_DONG",
                table: "HOP_DONG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MA_HOP_DONG",
                table: "HOP_DONG",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
