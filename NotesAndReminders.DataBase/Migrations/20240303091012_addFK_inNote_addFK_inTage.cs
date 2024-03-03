using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotesAndReminders.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class addFK_inNote_addFK_inTage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Tages_TagId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_TagId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Notes");

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
                name: "TagId",
                table: "Notes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TagId",
                table: "Notes",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Tages_TagId",
                table: "Notes",
                column: "TagId",
                principalTable: "Tages",
                principalColumn: "TagId");
        }
    }
}
