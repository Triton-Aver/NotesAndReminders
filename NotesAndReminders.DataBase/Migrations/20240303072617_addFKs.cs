using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NotesAndReminders.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class addFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tages_Notes_NoteId",
                table: "Tages");

            migrationBuilder.DropIndex(
                name: "IX_Tages_NoteId",
                table: "Tages");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "Tages");

            migrationBuilder.AlterColumn<int>(
                name: "ReminderId",
                table: "Reminders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Reminders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Reminders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "NoteTage",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteTage", x => new { x.NoteId, x.TagId });
                    table.ForeignKey(
                        name: "FK_NoteTage_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteTage_Tages_TagId",
                        column: x => x.TagId,
                        principalTable: "Tages",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteTage_TagId",
                table: "NoteTage",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_Notes_ReminderId",
                table: "Reminders",
                column: "ReminderId",
                principalTable: "Notes",
                principalColumn: "NoteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_Notes_ReminderId",
                table: "Reminders");

            migrationBuilder.DropTable(
                name: "NoteTage");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Reminders");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Reminders");

            migrationBuilder.AddColumn<int>(
                name: "NoteId",
                table: "Tages",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReminderId",
                table: "Reminders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Tages_NoteId",
                table: "Tages",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tages_Notes_NoteId",
                table: "Tages",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "NoteId");
        }
    }
}
