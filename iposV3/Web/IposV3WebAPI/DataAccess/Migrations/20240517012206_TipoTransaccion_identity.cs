using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IposV3.Migrations
{
    public partial class TipoTransaccion_identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Tipotransaccion\" ", true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Tipotransaccion",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "CreadoPorId",
                table: "Tipotransaccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EmpresaId",
                table: "Tipotransaccion",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModificadoPorId",
                table: "Tipotransaccion",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SucursalId",
                table: "Tipotransaccion",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tipotransaccion_EmpresaId_SucursalId_CreadoPorId",
                table: "Tipotransaccion",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Tipotransaccion_EmpresaId_SucursalId_ModificadoPorId",
                table: "Tipotransaccion",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tipotransaccion_Empresa_EmpresaId",
                table: "Tipotransaccion",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tipotransaccion_Sucursal_EmpresaId_SucursalId",
                table: "Tipotransaccion",
                columns: new[] { "EmpresaId", "SucursalId" },
                principalTable: "Sucursal",
                principalColumns: new[] { "EmpresaId", "Id" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tipotransaccion_Usuario_EmpresaId_SucursalId_CreadoPorId",
                table: "Tipotransaccion",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" },
                principalTable: "Usuario",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tipotransaccion_Usuario_EmpresaId_SucursalId_ModificadoPorId",
                table: "Tipotransaccion",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" },
                principalTable: "Usuario",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tipotransaccion_Empresa_EmpresaId",
                table: "Tipotransaccion");

            migrationBuilder.DropForeignKey(
                name: "FK_Tipotransaccion_Sucursal_EmpresaId_SucursalId",
                table: "Tipotransaccion");

            migrationBuilder.DropForeignKey(
                name: "FK_Tipotransaccion_Usuario_EmpresaId_SucursalId_CreadoPorId",
                table: "Tipotransaccion");

            migrationBuilder.DropForeignKey(
                name: "FK_Tipotransaccion_Usuario_EmpresaId_SucursalId_ModificadoPorId",
                table: "Tipotransaccion");

            migrationBuilder.DropIndex(
                name: "IX_Tipotransaccion_EmpresaId_SucursalId_CreadoPorId",
                table: "Tipotransaccion");

            migrationBuilder.DropIndex(
                name: "IX_Tipotransaccion_EmpresaId_SucursalId_ModificadoPorId",
                table: "Tipotransaccion");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "Tipotransaccion");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Tipotransaccion");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "Tipotransaccion");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "Tipotransaccion");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Tipotransaccion",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
