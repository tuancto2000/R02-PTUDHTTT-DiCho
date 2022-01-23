using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class addusername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "USERNAME",
                table: "TAI_KHOAN",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TAI_KHOAN_USERNAME",
                table: "TAI_KHOAN",
                column: "USERNAME",
                unique: true,
                filter: "[USERNAME] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TAI_KHOAN_USERNAME",
                table: "TAI_KHOAN");

            migrationBuilder.DropColumn(
                name: "USERNAME",
                table: "TAI_KHOAN");
        }
    }
}
