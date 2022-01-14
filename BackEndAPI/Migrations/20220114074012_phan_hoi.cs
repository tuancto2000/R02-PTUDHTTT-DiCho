using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class phan_hoi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PHAN_HOI",
                columns: table => new
                {
                    MaPhanHoi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MA_NGUOI_PHAN_HOI = table.Column<int>(type: "int", nullable: false),
                    MA_NGUOI_DUOC_PHAN_HOI = table.Column<int>(type: "int", nullable: false),
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PHAN_HOI");
        }
    }
}
