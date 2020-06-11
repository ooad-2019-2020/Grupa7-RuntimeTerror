using Microsoft.EntityFrameworkCore.Migrations;

namespace Studentski_dom.Migrations
{
    public partial class CreatedByPrijavaObroka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "createdByUserId",
                table: "PrijavaObroka",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdByUserId",
                table: "PrijavaObroka");
        }
    }
}
