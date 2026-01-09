using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IposV3.Migrations
{
    public partial class Ajustar_Replicacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repltablagroupdef_Empresa_EmpresaId",
                table: "Repltablagroupdef");

            migrationBuilder.DropForeignKey(
                name: "FK_Repltablagroupdef_Sucursal_EmpresaId_SucursalId",
                table: "Repltablagroupdef");

            migrationBuilder.DropForeignKey(
                name: "FK_Repltablagroupdef_Usuario_EmpresaId_SucursalId_CreadoPorId",
                table: "Repltablagroupdef");

            migrationBuilder.DropForeignKey(
                name: "FK_Repltablagroupdef_Usuario_EmpresaId_SucursalId_ModificadoPo~",
                table: "Repltablagroupdef");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Repltablagroupdef",
                table: "Repltablagroupdef");

            migrationBuilder.DropIndex(
                name: "IX_Repltablagroupdef_EmpresaId_SucursalId_CreadoPorId",
                table: "Repltablagroupdef");

            migrationBuilder.DropIndex(
                name: "IX_Repltablagroupdef_EmpresaId_SucursalId_ModificadoPorId",
                table: "Repltablagroupdef");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Repltablagroupdef");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "Repltablagroupdef");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "Repltablagroupdef");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "Repltablagroupdef");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Repltablagroupdef",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repltablagroupdef",
                table: "Repltablagroupdef",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Repltablagroupdef",
                table: "Repltablagroupdef");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Repltablagroupdef",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "EmpresaId",
                table: "Repltablagroupdef",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SucursalId",
                table: "Repltablagroupdef",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreadoPorId",
                table: "Repltablagroupdef",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModificadoPorId",
                table: "Repltablagroupdef",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repltablagroupdef",
                table: "Repltablagroupdef",
                columns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Repltablagroupdef_EmpresaId_SucursalId_CreadoPorId",
                table: "Repltablagroupdef",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Repltablagroupdef_EmpresaId_SucursalId_ModificadoPorId",
                table: "Repltablagroupdef",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Repltablagroupdef_Empresa_EmpresaId",
                table: "Repltablagroupdef",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repltablagroupdef_Sucursal_EmpresaId_SucursalId",
                table: "Repltablagroupdef",
                columns: new[] { "EmpresaId", "SucursalId" },
                principalTable: "Sucursal",
                principalColumns: new[] { "EmpresaId", "Id" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repltablagroupdef_Usuario_EmpresaId_SucursalId_CreadoPorId",
                table: "Repltablagroupdef",
                columns: new[] { "EmpresaId", "SucursalId", "CreadoPorId" },
                principalTable: "Usuario",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Repltablagroupdef_Usuario_EmpresaId_SucursalId_ModificadoPo~",
                table: "Repltablagroupdef",
                columns: new[] { "EmpresaId", "SucursalId", "ModificadoPorId" },
                principalTable: "Usuario",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }
    }
}
