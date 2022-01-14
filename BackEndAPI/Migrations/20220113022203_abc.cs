using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NgayDangKy",
                table: "HOP_DONG",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgayDangKy",
                table: "HOP_DONG");
        }
    }
}
