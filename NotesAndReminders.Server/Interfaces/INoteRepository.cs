using NotesAndReminders.DataBase.Models;
using NotesAndReminders.Server.Repositories;

namespace NotesAndReminders.Server.Interfaces
{
    public interface INoteRepository: IRepositoryBase<Note>
    {
        void Update(Note obj);
    }
}
