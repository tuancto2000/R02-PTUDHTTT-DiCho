using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class addaddress2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NGUOI_DUNG_DIA_CHI_DiaChiMaDiaChi",
                table: "NGUOI_DUNG");

            migrationBuilder.DropIndex(
                name: "IX_NGUOI_DUNG_DiaChiMaDiaChi",
                table: "NGUOI_DUNG");

            migrationBuilder.DropColumn(
                name: "DiaChiMaDiaChi",
                table: "NGUOI_DUNG");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "CUA_HANG");

            migrationBuilder.AddColumn<int>(
                name: "MA_DIA_CHI",
                table: "CUA_HANG",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NGUOI_DUNG_MA_DIA_CHI",
                table: "NGUOI_DUNG",
                column: "MA_DIA_CHI");

            migrationBuilder.CreateIndex(
                name: "IX_CUA_HANG_MA_DIA_CHI",
                table: "CUA_HANG",
                column: "MA_DIA_CHI");

            migrationBuilder.AddForeignKey(
                name: "FK_CUA_HANG_DIA_CHI_MA_DIA_CHI",
                table: "CUA_HANG",
                column: "MA_DIA_CHI",
                principalTable: "DIA_CHI",
                principalColumn: "MA_DIA_CHI",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NGUOI_DUNG_DIA_CHI_MA_DIA_CHI",
                table: "NGUOI_DUNG",
                column: "MA_DIA_CHI",
                principalTable: "DIA_CHI",
                principalColumn: "MA_DIA_CHI",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CUA_HANG_DIA_CHI_MA_DIA_CHI",
                table: "CUA_HANG");

            migrationBuilder.DropForeignKey(
                name: "FK_NGUOI_DUNG_DIA_CHI_MA_DIA_CHI",
                table: "NGUOI_DUNG");

            migrationBuilder.DropIndex(
                name: "IX_NGUOI_DUNG_MA_DIA_CHI",
                table: "NGUOI_DUNG");

            migrationBuilder.DropIndex(
                name: "IX_CUA_HANG_MA_DIA_CHI",
                table: "CUA_HANG");

            migrationBuilder.DropColumn(
                name: "MA_DIA_CHI",
                table: "CUA_HANG");

            migrationBuilder.AddColumn<int>(
                name: "DiaChiMaDiaChi",
                table: "NGUOI_DUNG",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "CUA_HANG",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NGUOI_DUNG_DiaChiMaDiaChi",
                table: "NGUOI_DUNG",
                column: "DiaChiMaDiaChi");

            migrationBuilder.AddForeignKey(
                name: "FK_NGUOI_DUNG_DIA_CHI_DiaChiMaDiaChi",
                table: "NGUOI_DUNG",
                column: "DiaChiMaDiaChi",
                principalTable: "DIA_CHI",
                principalColumn: "MA_DIA_CHI",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
