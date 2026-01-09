using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IposV3.Migrations
{
    public partial class add_usardatosentrega_doctofact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Usardatosentrega",
                table: "Docto_fact_elect",
                type: "char(1)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usardatosentrega",
                table: "Docto_fact_elect");
        }
    }
}
