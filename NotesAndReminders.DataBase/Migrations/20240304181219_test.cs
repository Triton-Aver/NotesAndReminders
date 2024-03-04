using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotesAndReminders.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteTags");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "NoteTags",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteTags", x => new { x.NoteId, x.TagId });
                    table.ForeignKey(
                        name: "FK_NoteTags_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteTags_Tages_TagId",
                        column: x => x.TagId,
                        principalTable: "Tages",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteTags_TagId",
                table: "NoteTags",
                column: "TagId");
        }
    }
}
