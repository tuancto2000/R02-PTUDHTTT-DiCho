using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class addcontractimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChungNhanAnToanImg",
                table: "HOP_DONG",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GiayPhepKinhDoanhImg",
                table: "HOP_DONG",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HopDongImg",
                table: "HOP_DONG",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChungNhanAnToanImg",
                table: "HOP_DONG");

            migrationBuilder.DropColumn(
                name: "GiayPhepKinhDoanhImg",
                table: "HOP_DONG");

            migrationBuilder.DropColumn(
                name: "HopDongImg",
                table: "HOP_DONG");
        }
    }
}
