using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinAnalyzer.Data.EntityFramework.Migrations
{
    public partial class UpdatePersonRoomUpdateTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_persons_person_id",
                table: "account");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoom_persons_person_id",
                table: "PersonRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoom_room_room_id",
                table: "PersonRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_request_to_join_persons_person_id",
                table: "request_to_join");

            migrationBuilder.DropPrimaryKey(
                name: "PK_persons",
                table: "persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonRoom",
                table: "PersonRoom");

            migrationBuilder.RenameTable(
                name: "persons",
                newName: "person");

            migrationBuilder.RenameTable(
                name: "PersonRoom",
                newName: "person_room");

            migrationBuilder.RenameIndex(
                name: "IX_PersonRoom_room_id",
                table: "person_room",
                newName: "IX_person_room_room_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_person",
                table: "person",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_person_room",
                table: "person_room",
                columns: new[] { "person_id", "room_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_account_person_person_id",
                table: "account",
                column: "person_id",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_room_person_person_id",
                table: "person_room",
                column: "person_id",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_room_room_room_id",
                table: "person_room",
                column: "room_id",
                principalTable: "room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_request_to_join_person_person_id",
                table: "request_to_join",
                column: "person_id",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_person_person_id",
                table: "account");

            migrationBuilder.DropForeignKey(
                name: "FK_person_room_person_person_id",
                table: "person_room");

            migrationBuilder.DropForeignKey(
                name: "FK_person_room_room_room_id",
                table: "person_room");

            migrationBuilder.DropForeignKey(
                name: "FK_request_to_join_person_person_id",
                table: "request_to_join");

            migrationBuilder.DropPrimaryKey(
                name: "PK_person_room",
                table: "person_room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_person",
                table: "person");

            migrationBuilder.RenameTable(
                name: "person_room",
                newName: "PersonRoom");

            migrationBuilder.RenameTable(
                name: "person",
                newName: "persons");

            migrationBuilder.RenameIndex(
                name: "IX_person_room_room_id",
                table: "PersonRoom",
                newName: "IX_PersonRoom_room_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonRoom",
                table: "PersonRoom",
                columns: new[] { "person_id", "room_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_persons",
                table: "persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_account_persons_person_id",
                table: "account",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_request_to_join_persons_person_id",
                table: "request_to_join",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
