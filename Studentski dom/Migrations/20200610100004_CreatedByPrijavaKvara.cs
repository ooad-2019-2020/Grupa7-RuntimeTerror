using Microsoft.EntityFrameworkCore.Migrations;

namespace Studentski_dom.Migrations
{
    public partial class CreatedByPrijavaKvara : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "createdByUserId",
                table: "PrijavaKvara",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdByUserId",
                table: "PrijavaKvara");
        }
    }
}
