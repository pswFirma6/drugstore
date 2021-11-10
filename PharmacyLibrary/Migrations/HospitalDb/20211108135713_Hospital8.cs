using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyLibrary.Migrations.HospitalDb
{
    public partial class Hospital8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Hospitals",
               columns: table => new
               {
                   HospitalName = table.Column<string>(type: "text", nullable: false),
                   HospitalAddress = table.Column<string>(type: "text", nullable: true),
                   HospitalCity = table.Column<string>(type: "text", nullable: true),
                   PharmacyName = table.Column<string>(type: "text", nullable: true),
                   ApiKey = table.Column<string>(type: "text", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Hospitals", x => x.HospitalName);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
