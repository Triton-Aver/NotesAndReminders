using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotesAndReminders.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class removeFK_inNote_addFK_inTage : Migration
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
