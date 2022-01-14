using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PHAN_HOI");

            migrationBuilder.AddColumn<int>(
                name: "SoLuotDanhGia",
                table: "SAN_PHAM",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TrungBinhSao",
                table: "SAN_PHAM",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "DANH_GIA",
                columns: table => new
                {
                    MA_DANH_GIA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MA_NGUOI_DUNG = table.Column<int>(type: "int", nullable: false),
                    MA_CHI_TIET_DON_HANG = table.Column<int>(type: "int", nullable: false),
                    MA_SAN_PHAM = table.Column<int>(type: "int", nullable: false),
                    SAO = table.Column<int>(type: "int", nullable: false),
                    BINH_LUAN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DANH_GIA", x => x.MA_DANH_GIA);
                    table.ForeignKey(
                        name: "FK_DANH_GIA_CHI_TIET_DON_HANG_MA_CHI_TIET_DON_HANG",
                        column: x => x.MA_CHI_TIET_DON_HANG,
                        principalTable: "CHI_TIET_DON_HANG",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DANH_GIA_NGUOI_DUNG_MA_NGUOI_DUNG",
                        column: x => x.MA_NGUOI_DUNG,
                        principalTable: "NGUOI_DUNG",
                        principalColumn: "MA_NGUOI_DUNG",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DANH_GIA_SAN_PHAM_MA_SAN_PHAM",
                        column: x => x.MA_SAN_PHAM,
                        principalTable: "SAN_PHAM",
                        principalColumn: "MA_SP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DANH_GIA_MA_CHI_TIET_DON_HANG",
                table: "DANH_GIA",
                column: "MA_CHI_TIET_DON_HANG");

            migrationBuilder.CreateIndex(
                name: "IX_DANH_GIA_MA_NGUOI_DUNG",
                table: "DANH_GIA",
                column: "MA_NGUOI_DUNG");

            migrationBuilder.CreateIndex(
                name: "IX_DANH_GIA_MA_SAN_PHAM",
                table: "DANH_GIA",
                column: "MA_SAN_PHAM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DANH_GIA");

            migrationBuilder.DropColumn(
                name: "SoLuotDanhGia",
                table: "SAN_PHAM");

            migrationBuilder.DropColumn(
                name: "TrungBinhSao",
                table: "SAN_PHAM");

            migrationBuilder.CreateTable(
                name: "PHAN_HOI",
                columns: table => new
                {
                    MaPhanHoi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MA_NGUOI_DUOC_PHAN_HOI = table.Column<int>(type: "int", nullable: false),
                    MA_NGUOI_PHAN_HOI = table.Column<int>(type: "int", nullable: false),
                    NOI_DUNG = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHAN_HOI", x => x.MaPhanHoi);
                    table.ForeignKey(
                        name: "FK_PHAN_HOI_NGUOI_DUNG_MA_NGUOI_DUOC_PHAN_HOI",
                        column: x => x.MA_NGUOI_DUOC_PHAN_HOI,
                        principalTable: "NGUOI_DUNG",
                        principalColumn: "MA_NGUOI_DUNG",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PHAN_HOI_NGUOI_DUNG_MA_NGUOI_PHAN_HOI",
                        column: x => x.MA_NGUOI_PHAN_HOI,
                        principalTable: "NGUOI_DUNG",
                        principalColumn: "MA_NGUOI_DUNG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PHAN_HOI_MA_NGUOI_DUOC_PHAN_HOI",
                table: "PHAN_HOI",
                column: "MA_NGUOI_DUOC_PHAN_HOI");

            migrationBuilder.CreateIndex(
                name: "IX_PHAN_HOI_MA_NGUOI_PHAN_HOI",
                table: "PHAN_HOI",
                column: "MA_NGUOI_PHAN_HOI");
        }
    }
}
