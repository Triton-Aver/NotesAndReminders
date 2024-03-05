using NotesAndReminders.DataBase.Context;
using NotesAndReminders.DataBase.Models;
using NotesAndReminders.Server.Interfaces;

namespace NotesAndReminders.Server.Repositories
{
    public class ReminderRepository : RepositoryBase<Reminder>, IReminderRepository
    {
        private readonly ApplicationContext _db;

        public ReminderRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }        

        public void CreateReminder(Reminder obj)
        {
            Reminder reminder = new Reminder
            {
                DeadLine = obj.DeadLine,               
            };
            
                Note note = _db.Notes.Find(obj.Note.NoteId);
                reminder.Note = note;
            
            _db.Reminders.Add(reminder);
            _db.SaveChanges();            
        }
    }
}
