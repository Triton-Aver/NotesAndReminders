using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotesAndReminders.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class addFK_Tage_Note : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
