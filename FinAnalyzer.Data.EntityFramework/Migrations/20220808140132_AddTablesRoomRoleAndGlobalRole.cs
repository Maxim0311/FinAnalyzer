using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinAnalyzer.Data.EntityFramework.Migrations
{
    public partial class AddTablesRoomRoleAndGlobalRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "person_room",
                newName: "room_role_id");

            migrationBuilder.AddColumn<int>(
                name: "global_role_id",
                table: "person",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "global_role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_global_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "room_role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_role", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "global_role",
                columns: new[] { "Id", "delete_date", "title" },
                values: new object[,]
                {
                    { 1, null, "Admin" },
                    { 2, null, "User" }
                });

            migrationBuilder.InsertData(
                table: "room_role",
                columns: new[] { "Id", "delete_date", "title" },
                values: new object[,]
                {
                    { 1, null, "Creator" },
                    { 2, null, "Admin" },
                    { 3, null, "Participant" }
                });

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "Id",
                keyValue: 1,
                column: "global_role_id",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_person_room_room_role_id",
                table: "person_room",
                column: "room_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_global_role_id",
                table: "person",
                column: "global_role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_person_global_role_global_role_id",
                table: "person",
                column: "global_role_id",
                principalTable: "global_role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_room_room_role_room_role_id",
                table: "person_room",
                column: "room_role_id",
                principalTable: "room_role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_global_role_global_role_id",
                table: "person");

            migrationBuilder.DropForeignKey(
                name: "FK_person_room_room_role_room_role_id",
                table: "person_room");

            migrationBuilder.DropTable(
                name: "global_role");

            migrationBuilder.DropTable(
                name: "room_role");

            migrationBuilder.DropIndex(
                name: "IX_person_room_room_role_id",
                table: "person_room");

            migrationBuilder.DropIndex(
                name: "IX_person_global_role_id",
                table: "person");

            migrationBuilder.DropColumn(
                name: "global_role_id",
                table: "person");

            migrationBuilder.RenameColumn(
                name: "room_role_id",
                table: "person_room",
                newName: "role");
        }
    }
}
