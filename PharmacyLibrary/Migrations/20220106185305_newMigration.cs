using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyLibrary.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Offers",
                newName: "OfferDateRange_StartDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Offers",
                newName: "OfferDateRange_EndDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OfferDateRange_StartDate",
                table: "Offers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OfferDateRange_EndDate",
                table: "Offers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OfferDateRange_StartDate",
                table: "Offers",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "OfferDateRange_EndDate",
                table: "Offers",
                newName: "EndDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Offers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Offers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);
        }
    }
}
