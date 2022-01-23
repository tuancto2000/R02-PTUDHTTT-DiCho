using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class updateaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TOA_DO_TAY",
                table: "DIA_CHI",
                newName: "TOA_DO_BAC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TOA_DO_BAC",
                table: "DIA_CHI",
                newName: "TOA_DO_TAY");
        }
    }
}
