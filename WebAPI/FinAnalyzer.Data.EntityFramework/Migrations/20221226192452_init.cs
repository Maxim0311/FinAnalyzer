using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinAnalyzer.Data.EntityFramework.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account_type",
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
                    table.PrimaryKey("PK_account_type", x => x.Id);
                });

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
                name: "room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "transaction_type",
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
                    table.PrimaryKey("PK_transaction_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    firstname = table.Column<string>(type: "text", nullable: true),
                    lastname = table.Column<string>(type: "text", nullable: true),
                    middlename = table.Column<string>(type: "text", nullable: true),
                    global_role_id = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_person_global_role_global_role_id",
                        column: x => x.global_role_id,
                        principalTable: "global_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    is_expenditure = table.Column<bool>(type: "boolean", nullable: false),
                    icon_author = table.Column<string>(type: "text", nullable: false),
                    icon_name = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false),
                    room_id = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_category_room_room_id",
                        column: x => x.room_id,
                        principalTable: "room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    balance = table.Column<decimal>(type: "numeric", nullable: false),
                    account_type_id = table.Column<int>(type: "integer", nullable: false),
                    room_id = table.Column<int>(type: "integer", nullable: false),
                    person_id = table.Column<int>(type: "integer", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_account_account_type_account_type_id",
                        column: x => x.account_type_id,
                        principalTable: "account_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_account_person_person_id",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_account_room_room_id",
                        column: x => x.room_id,
                        principalTable: "room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "person_room",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "integer", nullable: false),
                    room_id = table.Column<int>(type: "integer", nullable: false),
                    room_role_id = table.Column<int>(type: "integer", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_room", x => new { x.person_id, x.room_id });
                    table.ForeignKey(
                        name: "FK_person_room_person_person_id",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_room_room_role_room_role_id",
                        column: x => x.room_role_id,
                        principalTable: "room_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_room_room_room_id",
                        column: x => x.room_id,
                        principalTable: "room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "request_to_join",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    room_id = table.Column<int>(type: "integer", nullable: false),
                    person_id = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_request_to_join", x => x.Id);
                    table.ForeignKey(
                        name: "FK_request_to_join_person_person_id",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_request_to_join_room_room_id",
                        column: x => x.room_id,
                        principalTable: "room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    transaction_type_id = table.Column<int>(type: "integer", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: true),
                    destination_id = table.Column<int>(type: "integer", nullable: false),
                    sender_id = table.Column<int>(type: "integer", nullable: false),
                    room_id = table.Column<int>(type: "integer", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_account_destination_id",
                        column: x => x.destination_id,
                        principalTable: "account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_account_sender_id",
                        column: x => x.sender_id,
                        principalTable: "account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_room_room_id",
                        column: x => x.room_id,
                        principalTable: "room",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_transaction_type_transaction_type_id",
                        column: x => x.transaction_type_id,
                        principalTable: "transaction_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "account_type",
                columns: new[] { "Id", "delete_date", "title" },
                values: new object[,]
                {
                    { 1, null, "Person" },
                    { 2, null, "Room" },
                    { 3, null, "ThirdParty" }
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
                table: "room",
                columns: new[] { "Id", "delete_date", "description", "name" },
                values: new object[] { 1, null, "description", "testRoom" });

            migrationBuilder.InsertData(
                table: "room_role",
                columns: new[] { "Id", "delete_date", "title" },
                values: new object[,]
                {
                    { 1, null, "Creator" },
                    { 2, null, "Admin" },
                    { 3, null, "Participant" }
                });

            migrationBuilder.InsertData(
                table: "transaction_type",
                columns: new[] { "Id", "delete_date", "title" },
                values: new object[,]
                {
                    { 1, null, "Income" },
                    { 2, null, "Expenditure" },
                    { 3, null, "Transfer" }
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "Id", "color", "delete_date", "description", "icon_author", "icon_name", "is_expenditure", "name", "room_id" },
                values: new object[] { 1, "black", null, "description", "test", "test", false, "testCategory", 1 });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "Id", "delete_date", "firstname", "global_role_id", "lastname", "login", "middlename", "password" },
                values: new object[] { 1, null, "test", 1, "test", "admin", "test", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_account_account_type_id",
                table: "account",
                column: "account_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_account_person_id",
                table: "account",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_account_room_id",
                table: "account",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_room_id",
                table: "category",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_global_role_id",
                table: "person",
                column: "global_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_room_room_id",
                table: "person_room",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_room_room_role_id",
                table: "person_room",
                column: "room_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_request_to_join_person_id",
                table: "request_to_join",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_request_to_join_room_id",
                table: "request_to_join",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_category_id",
                table: "transactions",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_destination_id",
                table: "transactions",
                column: "destination_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_room_id",
                table: "transactions",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_sender_id",
                table: "transactions",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_transaction_type_id",
                table: "transactions",
                column: "transaction_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "person_room");

            migrationBuilder.DropTable(
                name: "request_to_join");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "room_role");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "transaction_type");

            migrationBuilder.DropTable(
                name: "account_type");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "room");

            migrationBuilder.DropTable(
                name: "global_role");
        }
    }
}
