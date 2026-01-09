using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class FechaVence_ChangeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fechavence",
                table: "Docto_compra");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Fechavence",
                table: "Docto",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fechavence",
                table: "Docto");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Fechavence",
                table: "Docto_compra",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
