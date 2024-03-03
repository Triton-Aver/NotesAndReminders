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
        
        public void Update(Reminder reminder)
        {
            throw new NotImplementedException();
        }
    }
}
