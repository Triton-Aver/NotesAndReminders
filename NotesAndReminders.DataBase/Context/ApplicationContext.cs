using Microsoft.EntityFrameworkCore;
using NotesAndReminders.DataBase.Models;

namespace NotesAndReminders.DataBase.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {            
        }
        public DbSet<Tage> Tages { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Reminder> Reminders { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .Property(e => e.DateCreate)
                .HasConversion(v => v.UtcDateTime, v => new DateTimeOffset(v, TimeSpan.Zero));

            modelBuilder.Entity<Reminder>()
                .Property(e => e.DeadLine)
                .HasConversion(v => v.UtcDateTime, v => new DateTimeOffset(v, TimeSpan.Zero));
        }
    }   
}
