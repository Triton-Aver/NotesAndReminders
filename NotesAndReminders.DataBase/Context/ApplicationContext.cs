using Microsoft.EntityFrameworkCore;
using NotesAndReminders.DataBase.Models;

namespace NotesAndReminders.DataBase.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<Tage> Tages { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
    }
}
