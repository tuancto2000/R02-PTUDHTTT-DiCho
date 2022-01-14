using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class adduserisActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "KichHoat",
                table: "NGUOI_DUNG",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TongTien",
                table: "DON_HANG",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SO_LUONG",
                table: "CHI_TIET_DON_HANG",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DON_GIA",
                table: "CHI_TIET_DON_HANG",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KichHoat",
                table: "NGUOI_DUNG");

            migrationBuilder.DropColumn(
                name: "TongTien",
                table: "DON_HANG");

            migrationBuilder.AlterColumn<int>(
                name: "SO_LUONG",
                table: "CHI_TIET_DON_HANG",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DON_GIA",
                table: "CHI_TIET_DON_HANG",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
