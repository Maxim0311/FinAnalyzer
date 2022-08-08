using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinAnalyzer.Data.EntityFramework.Migrations
{
    public partial class UpdateTablePersonRoomAddFieldDeleteDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "person_room",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "person_room");
        }
    }
}
