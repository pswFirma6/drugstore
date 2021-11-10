using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyLibrary.Migrations.HospitalDb
{
    public partial class Hospital3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PharmacyName",
                table: "Hospitals",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PharmacyName",
                table: "Hospitals");
        }
    }
}
