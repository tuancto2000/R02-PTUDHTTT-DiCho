using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class addhopdongpk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MA_HOP_DONG",
                table: "HOP_DONG",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HOP_DONG",
                table: "HOP_DONG",
                column: "MA_HOP_DONG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HOP_DONG",
                table: "HOP_DONG");

            migrationBuilder.DropColumn(
                name: "MA_HOP_DONG",
                table: "HOP_DONG");
        }
    }
}
