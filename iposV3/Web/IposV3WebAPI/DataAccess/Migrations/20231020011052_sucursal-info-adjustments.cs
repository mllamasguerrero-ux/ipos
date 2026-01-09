using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class sucursalinfoadjustments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sucursal_fact_elect_Sucursal_info_EmpresaId_SucursalId_Sucu~",
                table: "Sucursal_fact_elect");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursal_info_opciones_Sucursal_fact_elect_Sucursal_fact_el~",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursal_info_opciones_Sucursal_importacion_Sucursal_import~",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursal_info_opciones_Sucursal_respaldo_Sucursal_respaldoE~",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursal_info_opciones_Sucursal_traslado_Sucursal_trasladoE~",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursal_respaldo_Sucursal_info_EmpresaId_SucursalId_Sucurs~",
                table: "Sucursal_respaldo");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursal_traslado_Sucursal_info_EmpresaId_SucursalId_Sucurs~",
                table: "Sucursal_traslado");

            migrationBuilder.DropIndex(
                name: "IX_Sucursal_traslado_EmpresaId_SucursalId_Sucursalinfoid",
                table: "Sucursal_traslado");

            migrationBuilder.DropIndex(
                name: "IX_Sucursal_respaldo_EmpresaId_SucursalId_Sucursalinfoid",
                table: "Sucursal_respaldo");

            migrationBuilder.DropIndex(
                name: "IX_Sucursal_info_opciones_Sucursal_fact_electEmpresaId_Sucursa~",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropIndex(
                name: "IX_Sucursal_info_opciones_Sucursal_importacionEmpresaId_Sucurs~",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropIndex(
                name: "IX_Sucursal_info_opciones_Sucursal_respaldoEmpresaId_Sucursal_~",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropIndex(
                name: "IX_Sucursal_info_opciones_Sucursal_trasladoEmpresaId_Sucursal_~",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropIndex(
                name: "IX_Sucursal_fact_elect_EmpresaId_SucursalId_Sucursalinfoid",
                table: "Sucursal_fact_elect");

            migrationBuilder.DropColumn(
                name: "Sucursal_fact_electEmpresaId",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropColumn(
                name: "Sucursal_fact_electId",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropColumn(
                name: "Sucursal_fact_electSucursalId",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropColumn(
                name: "Sucursal_importacionEmpresaId",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropColumn(
                name: "Sucursal_importacionId",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropColumn(
                name: "Sucursal_importacionSucursalId",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropColumn(
                name: "Sucursal_respaldoEmpresaId",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropColumn(
                name: "Sucursal_respaldoId",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropColumn(
                name: "Sucursal_respaldoSucursalId",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropColumn(
                name: "Sucursal_trasladoEmpresaId",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropColumn(
                name: "Sucursal_trasladoId",
                table: "Sucursal_info_opciones");

            migrationBuilder.DropColumn(
                name: "Sucursal_trasladoSucursalId",
                table: "Sucursal_info_opciones");

            migrationBuilder.RenameColumn(
                name: "Sucursalinfoid",
                table: "Sucursal_traslado",
                newName: "Sucursal_info_opciones_id");

            migrationBuilder.RenameColumn(
                name: "Sucursalinfoid",
                table: "Sucursal_respaldo",
                newName: "Sucursal_info_opciones_id");

            migrationBuilder.RenameColumn(
                name: "Sucursalinfoid",
                table: "Sucursal_fact_elect",
                newName: "Sucursal_info_opciones_id");

            migrationBuilder.AddColumn<long>(
                name: "Sucursal_info_opciones_id",
                table: "Sucursal_importacion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_traslado_EmpresaId_SucursalId_Sucursal_info_opcion~",
                table: "Sucursal_traslado",
                columns: new[] { "EmpresaId", "SucursalId", "Sucursal_info_opciones_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_respaldo_EmpresaId_SucursalId_Sucursal_info_opcion~",
                table: "Sucursal_respaldo",
                columns: new[] { "EmpresaId", "SucursalId", "Sucursal_info_opciones_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_importacion_EmpresaId_SucursalId_Sucursal_info_opc~",
                table: "Sucursal_importacion",
                columns: new[] { "EmpresaId", "SucursalId", "Sucursal_info_opciones_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_fact_elect_EmpresaId_SucursalId_Sucursal_info_opci~",
                table: "Sucursal_fact_elect",
                columns: new[] { "EmpresaId", "SucursalId", "Sucursal_info_opciones_id" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursal_fact_elect_Sucursal_info_opciones_EmpresaId_Sucurs~",
                table: "Sucursal_fact_elect",
                columns: new[] { "EmpresaId", "SucursalId", "Sucursal_info_opciones_id" },
                principalTable: "Sucursal_info_opciones",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursal_importacion_Sucursal_info_opciones_EmpresaId_Sucur~",
                table: "Sucursal_importacion",
                columns: new[] { "EmpresaId", "SucursalId", "Sucursal_info_opciones_id" },
                principalTable: "Sucursal_info_opciones",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursal_respaldo_Sucursal_info_opciones_EmpresaId_Sucursal~",
                table: "Sucursal_respaldo",
                columns: new[] { "EmpresaId", "SucursalId", "Sucursal_info_opciones_id" },
                principalTable: "Sucursal_info_opciones",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursal_traslado_Sucursal_info_opciones_EmpresaId_Sucursal~",
                table: "Sucursal_traslado",
                columns: new[] { "EmpresaId", "SucursalId", "Sucursal_info_opciones_id" },
                principalTable: "Sucursal_info_opciones",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sucursal_fact_elect_Sucursal_info_opciones_EmpresaId_Sucurs~",
                table: "Sucursal_fact_elect");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursal_importacion_Sucursal_info_opciones_EmpresaId_Sucur~",
                table: "Sucursal_importacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursal_respaldo_Sucursal_info_opciones_EmpresaId_Sucursal~",
                table: "Sucursal_respaldo");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursal_traslado_Sucursal_info_opciones_EmpresaId_Sucursal~",
                table: "Sucursal_traslado");

            migrationBuilder.DropIndex(
                name: "IX_Sucursal_traslado_EmpresaId_SucursalId_Sucursal_info_opcion~",
                table: "Sucursal_traslado");

            migrationBuilder.DropIndex(
                name: "IX_Sucursal_respaldo_EmpresaId_SucursalId_Sucursal_info_opcion~",
                table: "Sucursal_respaldo");

            migrationBuilder.DropIndex(
                name: "IX_Sucursal_importacion_EmpresaId_SucursalId_Sucursal_info_opc~",
                table: "Sucursal_importacion");

            migrationBuilder.DropIndex(
                name: "IX_Sucursal_fact_elect_EmpresaId_SucursalId_Sucursal_info_opci~",
                table: "Sucursal_fact_elect");

            migrationBuilder.DropColumn(
                name: "Sucursal_info_opciones_id",
                table: "Sucursal_importacion");

            migrationBuilder.RenameColumn(
                name: "Sucursal_info_opciones_id",
                table: "Sucursal_traslado",
                newName: "Sucursalinfoid");

            migrationBuilder.RenameColumn(
                name: "Sucursal_info_opciones_id",
                table: "Sucursal_respaldo",
                newName: "Sucursalinfoid");

            migrationBuilder.RenameColumn(
                name: "Sucursal_info_opciones_id",
                table: "Sucursal_fact_elect",
                newName: "Sucursalinfoid");

            migrationBuilder.AddColumn<long>(
                name: "Sucursal_fact_electEmpresaId",
                table: "Sucursal_info_opciones",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sucursal_fact_electId",
                table: "Sucursal_info_opciones",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sucursal_fact_electSucursalId",
                table: "Sucursal_info_opciones",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sucursal_importacionEmpresaId",
                table: "Sucursal_info_opciones",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sucursal_importacionId",
                table: "Sucursal_info_opciones",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sucursal_importacionSucursalId",
                table: "Sucursal_info_opciones",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sucursal_respaldoEmpresaId",
                table: "Sucursal_info_opciones",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sucursal_respaldoId",
                table: "Sucursal_info_opciones",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sucursal_respaldoSucursalId",
                table: "Sucursal_info_opciones",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sucursal_trasladoEmpresaId",
                table: "Sucursal_info_opciones",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sucursal_trasladoId",
                table: "Sucursal_info_opciones",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Sucursal_trasladoSucursalId",
                table: "Sucursal_info_opciones",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_traslado_EmpresaId_SucursalId_Sucursalinfoid",
                table: "Sucursal_traslado",
                columns: new[] { "EmpresaId", "SucursalId", "Sucursalinfoid" });

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_respaldo_EmpresaId_SucursalId_Sucursalinfoid",
                table: "Sucursal_respaldo",
                columns: new[] { "EmpresaId", "SucursalId", "Sucursalinfoid" });

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_info_opciones_Sucursal_fact_electEmpresaId_Sucursa~",
                table: "Sucursal_info_opciones",
                columns: new[] { "Sucursal_fact_electEmpresaId", "Sucursal_fact_electSucursalId", "Sucursal_fact_electId" });

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_info_opciones_Sucursal_importacionEmpresaId_Sucurs~",
                table: "Sucursal_info_opciones",
                columns: new[] { "Sucursal_importacionEmpresaId", "Sucursal_importacionSucursalId", "Sucursal_importacionId" });

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_info_opciones_Sucursal_respaldoEmpresaId_Sucursal_~",
                table: "Sucursal_info_opciones",
                columns: new[] { "Sucursal_respaldoEmpresaId", "Sucursal_respaldoSucursalId", "Sucursal_respaldoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_info_opciones_Sucursal_trasladoEmpresaId_Sucursal_~",
                table: "Sucursal_info_opciones",
                columns: new[] { "Sucursal_trasladoEmpresaId", "Sucursal_trasladoSucursalId", "Sucursal_trasladoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_fact_elect_EmpresaId_SucursalId_Sucursalinfoid",
                table: "Sucursal_fact_elect",
                columns: new[] { "EmpresaId", "SucursalId", "Sucursalinfoid" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursal_fact_elect_Sucursal_info_EmpresaId_SucursalId_Sucu~",
                table: "Sucursal_fact_elect",
                columns: new[] { "EmpresaId", "SucursalId", "Sucursalinfoid" },
                principalTable: "Sucursal_info",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursal_info_opciones_Sucursal_fact_elect_Sucursal_fact_el~",
                table: "Sucursal_info_opciones",
                columns: new[] { "Sucursal_fact_electEmpresaId", "Sucursal_fact_electSucursalId", "Sucursal_fact_electId" },
                principalTable: "Sucursal_fact_elect",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursal_info_opciones_Sucursal_importacion_Sucursal_import~",
                table: "Sucursal_info_opciones",
                columns: new[] { "Sucursal_importacionEmpresaId", "Sucursal_importacionSucursalId", "Sucursal_importacionId" },
                principalTable: "Sucursal_importacion",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursal_info_opciones_Sucursal_respaldo_Sucursal_respaldoE~",
                table: "Sucursal_info_opciones",
                columns: new[] { "Sucursal_respaldoEmpresaId", "Sucursal_respaldoSucursalId", "Sucursal_respaldoId" },
                principalTable: "Sucursal_respaldo",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursal_info_opciones_Sucursal_traslado_Sucursal_trasladoE~",
                table: "Sucursal_info_opciones",
                columns: new[] { "Sucursal_trasladoEmpresaId", "Sucursal_trasladoSucursalId", "Sucursal_trasladoId" },
                principalTable: "Sucursal_traslado",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursal_respaldo_Sucursal_info_EmpresaId_SucursalId_Sucurs~",
                table: "Sucursal_respaldo",
                columns: new[] { "EmpresaId", "SucursalId", "Sucursalinfoid" },
                principalTable: "Sucursal_info",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursal_traslado_Sucursal_info_EmpresaId_SucursalId_Sucurs~",
                table: "Sucursal_traslado",
                columns: new[] { "EmpresaId", "SucursalId", "Sucursalinfoid" },
                principalTable: "Sucursal_info",
                principalColumns: new[] { "EmpresaId", "SucursalId", "Id" });
        }
    }
}
