using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class Parametros_Ajustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lista_precio_def",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Precioajustedifinv",
                table: "Parametro");


            migrationBuilder.DropColumn(
                name: "Tiposyncmovil",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Tiposeleccioncatalogosat",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Pvcolorear",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Ordenimpresion",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Formatofactelect",
                table: "Parametro");

            migrationBuilder.AddColumn<short>(
                name: "Tiposyncmovil",
                table: "Parametro",
                type: "smallint",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Tiposeleccioncatalogosat",
                table: "Parametro",
                type: "smallint",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Pvcolorear",
                table: "Parametro",
                type: "smallint",
                nullable: false);

            migrationBuilder.AddColumn<short>(
                name: "Ordenimpresion",
                table: "Parametro",
                type: "smallint",
                maxLength: 31,
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Formatofactelect",
                table: "Parametro",
                type: "smallint",
                maxLength: 31,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Lista_precio_defid",
                table: "Parametro",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Precioajustedifinvid",
                table: "Parametro",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Campoimpocostorepoid",
                table: "Parametro",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Formatoticketcortoid",
                table: "Parametro",
                type: "smallint",
                nullable: true);


            migrationBuilder.AddColumn<short>(
                name: "Screenconfig",
                table: "Parametro",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Tipovendedormovil",
                table: "Parametro",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Vendedormovilid",
                table: "Parametro",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parametro_Campoimpocostorepoid",
                table: "Parametro",
                column: "Campoimpocostorepoid");

            migrationBuilder.CreateIndex(
                name: "IX_Parametro_EmpresaId_SucursalId_Vendedormovilid",
                table: "Parametro",
                columns: new[] { "EmpresaId", "SucursalId", "Vendedormovilid" });

            migrationBuilder.CreateIndex(
                name: "IX_Parametro_Lista_precio_defid",
                table: "Parametro",
                column: "Lista_precio_defid");

            migrationBuilder.CreateIndex(
                name: "IX_Parametro_Precioajustedifinvid",
                table: "Parametro",
                column: "Precioajustedifinvid");

            migrationBuilder.AddForeignKey(
                name: "FK_Parametro_Tipoprecio_Campoimpocostorepoid",
                table: "Parametro",
                column: "Campoimpocostorepoid",
                principalTable: "Tipoprecio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parametro_Tipoprecio_Lista_precio_defid",
                table: "Parametro",
                column: "Lista_precio_defid",
                principalTable: "Tipoprecio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parametro_Tipoprecio_Precioajustedifinvid",
                table: "Parametro",
                column: "Precioajustedifinvid",
                principalTable: "Tipoprecio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parametro_Usuario_EmpresaId_SucursalId_Vendedormovilid",
                table: "Parametro",
                columns: new[] { "EmpresaId", "SucursalId", "Vendedormovilid" },
                principalTable: "Usuario",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parametro_Tipoprecio_Campoimpocostorepoid",
                table: "Parametro");

            migrationBuilder.DropForeignKey(
                name: "FK_Parametro_Tipoprecio_Lista_precio_defid",
                table: "Parametro");

            migrationBuilder.DropForeignKey(
                name: "FK_Parametro_Tipoprecio_Precioajustedifinvid",
                table: "Parametro");

            migrationBuilder.DropForeignKey(
                name: "FK_Parametro_Usuario_EmpresaId_SucursalId_Vendedormovilid",
                table: "Parametro");

            migrationBuilder.DropIndex(
                name: "IX_Parametro_Campoimpocostorepoid",
                table: "Parametro");

            migrationBuilder.DropIndex(
                name: "IX_Parametro_EmpresaId_SucursalId_Vendedormovilid",
                table: "Parametro");

            migrationBuilder.DropIndex(
                name: "IX_Parametro_Lista_precio_defid",
                table: "Parametro");

            migrationBuilder.DropIndex(
                name: "IX_Parametro_Precioajustedifinvid",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Campoimpocostorepoid",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Formatoticketcortoid",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Lista_precio_defid",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Precioajustedifinvid",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Screenconfig",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Tipovendedormovil",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Vendedormovilid",
                table: "Parametro");

            migrationBuilder.AlterColumn<string>(
                name: "Tiposyncmovil",
                table: "Parametro",
                type: "character varying(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tiposeleccioncatalogosat",
                table: "Parametro",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Pvcolorear",
                table: "Parametro",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "Ordenimpresion",
                table: "Parametro",
                type: "character varying(31)",
                maxLength: 31,
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Formatofactelect",
                table: "Parametro",
                type: "character varying(31)",
                maxLength: 31,
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lista_precio_def",
                table: "Parametro",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Precioajustedifinv",
                table: "Parametro",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);
        }
    }
}
