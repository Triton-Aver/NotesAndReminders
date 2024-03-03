using NotesAndReminders.DataBase.Models;

namespace NotesAndReminders.Server.Interfaces
{
    public interface IReminderRepository: IRepositoryBase<Reminder>
    {
        void Update(Reminder reminder);
    }
}
