using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotesAndReminders.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteTage");

            migrationBuilder.AddColumn<int>(
                name: "NoteId",
                table: "Tages",
                type: "integer",
                nullable: true);

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
