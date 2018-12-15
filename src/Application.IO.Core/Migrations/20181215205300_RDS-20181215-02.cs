using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.IO.Core.Migrations
{
    public partial class RDS2018121502 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LogicalDeleted",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogicalDeleted",
                table: "AspNetUsers");
        }
    }
}
