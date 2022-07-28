using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinAnalyzer.Data.EntityFramework.Migrations
{
    public partial class UpdatePersonRoomUpdatePropertyRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_room_persons_user_id",
                table: "user_room");

            migrationBuilder.DropForeignKey(
                name: "FK_user_room_room_room_id",
                table: "user_room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_room",
                table: "user_room");

            migrationBuilder.RenameTable(
                name: "user_room",
                newName: "person_room");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "person_room",
                newName: "person_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_room_room_id",
                table: "person_room",
                newName: "IX_person_room_room_id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameTable(
                name: "person_room",
                newName: "user_room");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "user_room",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_person_room_room_id",
                table: "user_room",
                newName: "IX_user_room_room_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_room",
                table: "user_room",
                columns: new[] { "user_id", "room_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_user_room_persons_user_id",
                table: "user_room",
                column: "user_id",
                principalTable: "persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_room_room_room_id",
                table: "user_room",
                column: "room_id",
                principalTable: "room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
