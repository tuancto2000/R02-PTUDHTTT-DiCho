using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class addaddress1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DIA_CHI",
                table: "NGUOI_DUNG");

            migrationBuilder.AddColumn<int>(
                name: "DiaChiMaDiaChi",
                table: "NGUOI_DUNG",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MA_DIA_CHI",
                table: "NGUOI_DUNG",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DIA_CHI",
                columns: table => new
                {
                    MA_DIA_CHI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEN_DIA_CHI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOA_DO_DONG = table.Column<int>(type: "int", nullable: false),
                    TOA_DO_TAY = table.Column<int>(type: "int", nullable: false),
                    LOAI_VUNG = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIA_CHI", x => x.MA_DIA_CHI);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NGUOI_DUNG_DIA_CHI_DiaChiMaDiaChi",
                table: "NGUOI_DUNG");

            migrationBuilder.DropTable(
                name: "DIA_CHI");

            migrationBuilder.DropIndex(
                name: "IX_NGUOI_DUNG_DiaChiMaDiaChi",
                table: "NGUOI_DUNG");

            migrationBuilder.DropColumn(
                name: "DiaChiMaDiaChi",
                table: "NGUOI_DUNG");

            migrationBuilder.DropColumn(
                name: "MA_DIA_CHI",
                table: "NGUOI_DUNG");

            migrationBuilder.AddColumn<string>(
                name: "DIA_CHI",
                table: "NGUOI_DUNG",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
