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
        public DbSet<NoteTag> NoteTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteTag>()
            .HasKey(nt => new { nt.NoteId, nt.TagId });

            modelBuilder.Entity<NoteTag>()
                .HasOne(nt => nt.Note)
                .WithMany(n => n.NoteTags)
                .HasForeignKey(nt => nt.NoteId);

            modelBuilder.Entity<NoteTag>()
                .HasOne(nt => nt.Tag)
                .WithMany(t => t.NoteTags)
                .HasForeignKey(nt => nt.TagId);

            modelBuilder.Entity<Note>()
                .Property(e => e.DateCreate)
                .HasConversion(v => v.UtcDateTime, v => new DateTimeOffset(v, TimeSpan.Zero));

            modelBuilder.Entity<Reminder>()
                .Property(e => e.DeadLine)
                .HasConversion(v => v.UtcDateTime, v => new DateTimeOffset(v, TimeSpan.Zero));
        }
    }   
}
