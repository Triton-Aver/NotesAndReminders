using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotesAndReminders.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class removeDiscriptionInReminder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Reminders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Reminders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
