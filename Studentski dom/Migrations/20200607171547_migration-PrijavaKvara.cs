using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Studentski_dom.Migrations
{
    public partial class migrationPrijavaKvara : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VrijemeRjesenja",
                table: "PrijavaKvara");

            migrationBuilder.AddColumn<bool>(
                name: "Rijeseno",
                table: "PrijavaKvara",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rijeseno",
                table: "PrijavaKvara");

            migrationBuilder.AddColumn<DateTime>(
                name: "VrijemeRjesenja",
                table: "PrijavaKvara",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
