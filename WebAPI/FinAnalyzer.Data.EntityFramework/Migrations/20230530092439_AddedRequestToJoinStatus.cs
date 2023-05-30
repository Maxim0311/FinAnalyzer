using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinAnalyzer.Data.EntityFramework.Migrations
{
    public partial class AddedRequestToJoinStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "request_to_join",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "request_to_join");
        }
    }
}
