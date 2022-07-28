using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinAnalyzer.Data.EntityFramework.Migrations
{
    public partial class FixedPersonRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_room_persons_person_id",
                table: "person_room");

            migrationBuilder.DropForeignKey(
                name: "FK_person_room_room_room_id",
                table: "person_room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_person_room",
                table: "person_room");

            migrationBuilder.DropColumn(
                name: "descriminator",
                table: "person_room");

            migrationBuilder.RenameTable(
                name: "person_room",
                newName: "PersonRoom");

            migrationBuilder.RenameIndex(
                name: "IX_person_room_room_id",
                table: "PersonRoom",
                newName: "IX_PersonRoom_room_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonRoom",
                table: "PersonRoom",
                columns: new[] { "person_id", "room_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRoom_persons_person_id",
                table: "PersonRoom",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRoom_room_room_id",
                table: "PersonRoom",
                column: "room_id",
                principalTable: "room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoom_persons_person_id",
                table: "PersonRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoom_room_room_id",
                table: "PersonRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonRoom",
                table: "PersonRoom");

            migrationBuilder.RenameTable(
                name: "PersonRoom",
                newName: "person_room");

            migrationBuilder.RenameIndex(
                name: "IX_PersonRoom_room_id",
                table: "person_room",
                newName: "IX_person_room_room_id");

            migrationBuilder.AddColumn<string>(
                name: "descriminator",
                table: "person_room",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_person_room",
                table: "person_room",
                columns: new[] { "person_id", "room_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_person_room_persons_person_id",
                table: "person_room",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_room_room_room_id",
                table: "person_room",
                column: "room_id",
                principalTable: "room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
