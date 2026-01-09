using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class Consecutivo_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Numero_consecutivo",
                table: "Maestro_consecutivo",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Numero_consecutivo",
                table: "Maestro_consecutivo",
                type: "integer",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
