using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DANH_MUC",
                columns: table => new
                {
                    MA_DM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEN_DM = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DANH_MUC", x => x.MA_DM);
                });

            migrationBuilder.CreateTable(
                name: "GOI_SAN_PHAM",
                columns: table => new
                {
                    MA_GOI_SP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEN_GOI_SP = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GOI_SAN_PHAM", x => x.MA_GOI_SP);
                });

            migrationBuilder.CreateTable(
                name: "NGUOI_DUNG",
                columns: table => new
                {
                    MA_NGUOI_DUNG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEN_NGUOI_DUNG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NGAY_SINH = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DIA_CHI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VAI_TRO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NGUOI_DUNG", x => x.MA_NGUOI_DUNG);
                });

            migrationBuilder.CreateTable(
                name: "CUA_HANG",
                columns: table => new
                {
                    MA_CUA_HANG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MA_NGUOI_DUNG = table.Column<int>(type: "int", nullable: false),
                    SDT = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TEN_CUA_HANG = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUA_HANG", x => x.MA_CUA_HANG);
                    table.ForeignKey(
                        name: "FK_CUA_HANG_NGUOI_DUNG_MA_NGUOI_DUNG",
                        column: x => x.MA_NGUOI_DUNG,
                        principalTable: "NGUOI_DUNG",
                        principalColumn: "MA_NGUOI_DUNG",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GIO_HANG",
                columns: table => new
                {
                    MA_GIO_HANG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MA_NGUOI_DUNG = table.Column<int>(type: "int", nullable: false),
                    TONG_TIEN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIO_HANG", x => x.MA_GIO_HANG);
                    table.ForeignKey(
                        name: "FK_GIO_HANG_NGUOI_DUNG_MA_GIO_HANG",
                        column: x => x.MA_GIO_HANG,
                        principalTable: "NGUOI_DUNG",
                        principalColumn: "MA_NGUOI_DUNG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HOP_DONG",
                columns: table => new
                {
                    MA_NGUOI_DUNG = table.Column<int>(type: "int", nullable: false),
                    MA_HOP_DONG = table.Column<int>(type: "int", nullable: false),
                    NGAY_KY_HOP_DONG = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NGAY_HIEU_LUC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NGAY_KET_THUC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_HOP_DONG_NGUOI_DUNG_MA_NGUOI_DUNG",
                        column: x => x.MA_NGUOI_DUNG,
                        principalTable: "NGUOI_DUNG",
                        principalColumn: "MA_NGUOI_DUNG",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TAI_KHOAN",
                columns: table => new
                {
                    MA_NGUOI_DUNG = table.Column<int>(type: "int", nullable: false),
                    MAT_KHAU = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAI_KHOAN", x => x.MA_NGUOI_DUNG);
                    table.ForeignKey(
                        name: "FK_TAI_KHOAN_NGUOI_DUNG_MA_NGUOI_DUNG",
                        column: x => x.MA_NGUOI_DUNG,
                        principalTable: "NGUOI_DUNG",
                        principalColumn: "MA_NGUOI_DUNG",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DON_HANG",
                columns: table => new
                {
                    MA_DON_HANG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MA_NGUOI_DUNG = table.Column<int>(type: "int", nullable: false),
                    MA_CUA_HANG = table.Column<int>(type: "int", nullable: false),
                    MA_SHIPPER = table.Column<int>(type: "int", nullable: true),
                    DIA_CHI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NGAY_MUA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TRANG_THAI = table.Column<int>(type: "int", nullable: false),
                    NGAY_CAP_NHAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TEN_NGUOI_NHAN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PHAN_HOI = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DON_HANG", x => x.MA_DON_HANG);
                    table.ForeignKey(
                        name: "FK_DON_HANG_CUA_HANG_MA_CUA_HANG",
                        column: x => x.MA_CUA_HANG,
                        principalTable: "CUA_HANG",
                        principalColumn: "MA_CUA_HANG",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DON_HANG_NGUOI_DUNG_MA_NGUOI_DUNG",
                        column: x => x.MA_NGUOI_DUNG,
                        principalTable: "NGUOI_DUNG",
                        principalColumn: "MA_NGUOI_DUNG",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DON_HANG_NGUOI_DUNG_MA_SHIPPER",
                        column: x => x.MA_SHIPPER,
                        principalTable: "NGUOI_DUNG",
                        principalColumn: "MA_NGUOI_DUNG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SAN_PHAM",
                columns: table => new
                {
                    MA_SP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MA_CUA_HANG = table.Column<int>(type: "int", nullable: false),
                    MA_DM = table.Column<int>(type: "int", nullable: false),
                    TEN_SP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GIA_SP = table.Column<int>(type: "int", nullable: true),
                    SO_LUONG_CON_LAI = table.Column<int>(type: "int", nullable: true),
                    MO_TA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAN_PHAM", x => x.MA_SP);
                    table.ForeignKey(
                        name: "FK_SAN_PHAM_CUA_HANG_MA_CUA_HANG",
                        column: x => x.MA_CUA_HANG,
                        principalTable: "CUA_HANG",
                        principalColumn: "MA_CUA_HANG",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SAN_PHAM_DANH_MUC_MA_DM",
                        column: x => x.MA_DM,
                        principalTable: "DANH_MUC",
                        principalColumn: "MA_DM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CHI_TIET_DON_HANG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MA_DON_HANG = table.Column<int>(type: "int", nullable: false),
                    MA_SP = table.Column<int>(type: "int", nullable: false),
                    SO_LUONG = table.Column<int>(type: "int", nullable: true),
                    DON_GIA = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHI_TIET_DON_HANG", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CHI_TIET_DON_HANG_DON_HANG_MA_DON_HANG",
                        column: x => x.MA_DON_HANG,
                        principalTable: "DON_HANG",
                        principalColumn: "MA_DON_HANG",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHI_TIET_DON_HANG_SAN_PHAM_MA_SP",
                        column: x => x.MA_SP,
                        principalTable: "SAN_PHAM",
                        principalColumn: "MA_SP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CHI_TIET_GIO_HANG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MA_GIO_HANG = table.Column<int>(type: "int", nullable: false),
                    MA_SP = table.Column<int>(type: "int", nullable: false),
                    SO_LUONG = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHI_TIET_GIO_HANG", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CHI_TIET_GIO_HANG_GIO_HANG_MA_GIO_HANG",
                        column: x => x.MA_GIO_HANG,
                        principalTable: "GIO_HANG",
                        principalColumn: "MA_GIO_HANG",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHI_TIET_GIO_HANG_SAN_PHAM_MA_SP",
                        column: x => x.MA_SP,
                        principalTable: "SAN_PHAM",
                        principalColumn: "MA_SP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CHI_TIET_GOI_SAN_PHAM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MA_SP = table.Column<int>(type: "int", nullable: false),
                    MA_GOI_SP = table.Column<int>(type: "int", nullable: false),
                    SO_LUONG = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHI_TIET_GOI_SAN_PHAM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CHI_TIET_GOI_SAN_PHAM_GOI_SAN_PHAM_MA_GOI_SP",
                        column: x => x.MA_GOI_SP,
                        principalTable: "GOI_SAN_PHAM",
                        principalColumn: "MA_GOI_SP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHI_TIET_GOI_SAN_PHAM_SAN_PHAM_MA_SP",
                        column: x => x.MA_SP,
                        principalTable: "SAN_PHAM",
                        principalColumn: "MA_SP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HINH_ANH",
                columns: table => new
                {
                    MA_HINH_ANH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MA_SP = table.Column<int>(type: "int", nullable: false),
                    NGUON_HINH_ANH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MAC_DINH = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HINH_ANH", x => x.MA_HINH_ANH);
                    table.ForeignKey(
                        name: "FK_HINH_ANH_SAN_PHAM_MA_SP",
                        column: x => x.MA_SP,
                        principalTable: "SAN_PHAM",
                        principalColumn: "MA_SP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHI_TIET_DON_HANG_MA_DON_HANG",
                table: "CHI_TIET_DON_HANG",
                column: "MA_DON_HANG");

            migrationBuilder.CreateIndex(
                name: "IX_CHI_TIET_DON_HANG_MA_SP",
                table: "CHI_TIET_DON_HANG",
                column: "MA_SP");

            migrationBuilder.CreateIndex(
                name: "IX_CHI_TIET_GIO_HANG_MA_GIO_HANG",
                table: "CHI_TIET_GIO_HANG",
                column: "MA_GIO_HANG");

            migrationBuilder.CreateIndex(
                name: "IX_CHI_TIET_GIO_HANG_MA_SP",
                table: "CHI_TIET_GIO_HANG",
                column: "MA_SP");

            migrationBuilder.CreateIndex(
                name: "IX_CHI_TIET_GOI_SAN_PHAM_MA_GOI_SP",
                table: "CHI_TIET_GOI_SAN_PHAM",
                column: "MA_GOI_SP");

            migrationBuilder.CreateIndex(
                name: "IX_CHI_TIET_GOI_SAN_PHAM_MA_SP",
                table: "CHI_TIET_GOI_SAN_PHAM",
                column: "MA_SP");

            migrationBuilder.CreateIndex(
                name: "IX_CUA_HANG_MA_NGUOI_DUNG",
                table: "CUA_HANG",
                column: "MA_NGUOI_DUNG");

            migrationBuilder.CreateIndex(
                name: "IX_DON_HANG_MA_CUA_HANG",
                table: "DON_HANG",
                column: "MA_CUA_HANG");

            migrationBuilder.CreateIndex(
                name: "IX_DON_HANG_MA_NGUOI_DUNG",
                table: "DON_HANG",
                column: "MA_NGUOI_DUNG");

            migrationBuilder.CreateIndex(
                name: "IX_DON_HANG_MA_SHIPPER",
                table: "DON_HANG",
                column: "MA_SHIPPER");

            migrationBuilder.CreateIndex(
                name: "IX_HINH_ANH_MA_SP",
                table: "HINH_ANH",
                column: "MA_SP");

            migrationBuilder.CreateIndex(
                name: "IX_HOP_DONG_MA_NGUOI_DUNG",
                table: "HOP_DONG",
                column: "MA_NGUOI_DUNG");

            migrationBuilder.CreateIndex(
                name: "IX_SAN_PHAM_MA_CUA_HANG",
                table: "SAN_PHAM",
                column: "MA_CUA_HANG");

            migrationBuilder.CreateIndex(
                name: "IX_SAN_PHAM_MA_DM",
                table: "SAN_PHAM",
                column: "MA_DM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHI_TIET_DON_HANG");

            migrationBuilder.DropTable(
                name: "CHI_TIET_GIO_HANG");

            migrationBuilder.DropTable(
                name: "CHI_TIET_GOI_SAN_PHAM");

            migrationBuilder.DropTable(
                name: "HINH_ANH");

            migrationBuilder.DropTable(
                name: "HOP_DONG");

            migrationBuilder.DropTable(
                name: "TAI_KHOAN");

            migrationBuilder.DropTable(
                name: "DON_HANG");

            migrationBuilder.DropTable(
                name: "GIO_HANG");

            migrationBuilder.DropTable(
                name: "GOI_SAN_PHAM");

            migrationBuilder.DropTable(
                name: "SAN_PHAM");

            migrationBuilder.DropTable(
                name: "CUA_HANG");

            migrationBuilder.DropTable(
                name: "DANH_MUC");

            migrationBuilder.DropTable(
                name: "NGUOI_DUNG");
        }
    }
}
